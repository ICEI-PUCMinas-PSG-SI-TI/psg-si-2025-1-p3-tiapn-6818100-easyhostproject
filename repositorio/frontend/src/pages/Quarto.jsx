import React, { useState, useEffect } from "react";
import { Table, Button, Modal, Form } from "react-bootstrap";
import Header from "./componente/Header";
import api from "../services/api";
import { jwtDecode } from "jwt-decode";

export default function Quarto() {
  const [quartos, setQuartos] = useState([]);
  const [show, setShow] = useState(false);
  const [modalType, setModalType] = useState("create");
  const [current, setCurrent] = useState({
    id: "",
    numQuarto: "",
    numCamasSolteiro: "",
    numCamasCasal: "",
    maxPessoas: "",
    hotelId: "",
    precoDiaria: "",
  });

  const [hotelId, setHotelId] = useState("");
  const [tipoUsuario, setTipoUsuario] = useState("");
  const [showPermissionModal, setShowPermissionModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [idToDelete, setIdToDelete] = useState(null);
  const [showBlockedModal, setShowBlockedModal] = useState(false);
  const [roomHasReserva, setRoomHasReserva] = useState({});
  const [erroValidacao, setErroValidacao] = useState("");
  const [nomeBtn, setNomeBtn] = useState("");

  const isAdmin = tipoUsuario === "Administrador";

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      try {
        const decoded = jwtDecode(token);
        setHotelId(decoded.hotelId || "");
        setTipoUsuario(decoded.tipoUsuario || "");
        fetchQuartosAndReservas(decoded.hotelId);
      } catch (err) {
        console.error("Erro ao decodificar token:", err);
      }
    }
  }, []);

  const fetchQuartosAndReservas = async (hotelId) => {
    try {
      const [quartosRes, reservasRes] = await Promise.all([
        api.get("/Quarto", { params: { hotelId } }),
        api.get("/Reserva", { params: { hotelId } })
      ]);
      const rooms = quartosRes.data;
      setQuartos(rooms);
      const reservas = reservasRes.data;
      const reservedSet = new Set(reservas.map(r => r._quartoId));
      const map = {};
      rooms.forEach(q => {
        map[q.id] = reservedSet.has(q.id);
      });
      setRoomHasReserva(map);
    } catch (err) {
      console.error("Erro ao buscar dados:", err);
    }
  };

  const handleShowCreate = () => {
    setModalType("create");
    setCurrent({
      id: "",
      numQuarto: "",
      numCamasSolteiro: "",
      numCamasCasal: "",
      maxPessoas: "",
      hotelId: "",
      precoDiaria: "",
    });
    setShow(true);
  };

  const handleShowEdit = (q) => {
    setModalType("edit");
    setCurrent({ ...q });
    setShow(true);
  };

  const handleClose = () => setShow(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCurrent((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const numQuarto = Number(current.numQuarto);
    const numCamasSolteiro = Number(current.numCamasSolteiro);
    const numCamasCasal = Number(current.numCamasCasal);
    const maxPessoas = Number(current.maxPessoas);
    const precoDiaria = Number(current.precoDiaria);

    if (modalType === "create" && numQuarto <= 0) {
      setErroValidacao("O número do quarto deve ser maior que zero.");
      return;
    }
    if (numCamasSolteiro < 0 || numCamasCasal < 0) {
      setErroValidacao("O número de camas não pode ser negativo.");
      return;
    }
    if (maxPessoas <= 0) {
      setErroValidacao("O número máximo de pessoas deve ser maior que zero.");
      return;
    }
    if (maxPessoas < numCamasSolteiro + numCamasCasal * 2) {
      setErroValidacao(
        "O número máximo de pessoas não pode ser menor que a capacidade total das camas."
      );
      return;
    }
    setErroValidacao("");
    try {
      if (modalType === "create") {
        await api.post("/Quarto/cadastrar", {
          numQuarto,
          numCamasSolteiro,
          numCamasCasal,
          maxPessoas,
          hotelId,
          precoDiaria,
        });
      } else {
        await api.put("/Quarto/alterar", {
          id: current.id,
          numCamasSolteiro,
          numCamasCasal,
          maxPessoas,
          precoDiaria,
        });
      }
      fetchQuartosAndReservas(hotelId);
      handleClose();
    } catch (err) {
      console.error("Erro no submit:", err);
    }
  };

  const handleDelete = async () => {
    try {
      await api.delete(`/Quarto/${idToDelete}`);
      fetchQuartosAndReservas(hotelId);
      setShowDeleteModal(false);
    } catch (err) {
      console.error("Erro ao deletar:", err);
    }
  };

  const confirmDelete = (id) => {
    setIdToDelete(id);
    setShowDeleteModal(true);
  };

  return (
    <>
      <Header />
      <div className="container mt-10">
        <h2>Gerenciamento de Quartos</h2>
        <Button
          variant="primary"
          className="mb-3 bg-dark"
          onClick={() => {
            setNomeBtn("criar");
            if (isAdmin) {
              handleShowCreate();
            } else {
              setShowPermissionModal(true);
            }
          }}
        >
          Novo Quarto
        </Button>

        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Nº Quarto</th>
              <th>Camas Solteiro</th>
              <th>Camas Casal</th>
              <th>Máx Pessoas</th>
              <th>Preço Diária</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {quartos.map((q) => (
              <tr key={q.id}>
                <td>{q.numQuarto}</td>
                <td>{q.numCamasSolteiro}</td>
                <td>{q.numCamasCasal}</td>
                <td>{q.maxPessoas}</td>
                <td>R$ {q.precoDiaria.toFixed(2)}</td>
                <td>
                  <Button
                    variant="warning"
                    size="sm"
                    className="me-2 bg-warning text-dark"
                    onClick={() => {
                      setNomeBtn("editar");
                      if (isAdmin) {
                        handleShowEdit(q);
                      } else {
                        setShowPermissionModal(true);
                      }
                    }}
                  >
                    Editar
                  </Button>
                  <Button
                    className="bg-danger text-white"
                    variant="danger"
                    size="sm"
                    disabled={!isAdmin || roomHasReserva[q.id]}
                    onClick={() => {
                      setNomeBtn("excluir");
                      if (!isAdmin) {
                        setShowPermissionModal(true);
                      } else if (roomHasReserva[q.id]) {
                        setShowBlockedModal(true);
                      } else {
                        confirmDelete(q.id);
                      }
                    }}
                  >
                    Excluir
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>

        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>
              {modalType === "create" ? "Novo Quarto" : "Editar Quarto"}
            </Modal.Title>
          </Modal.Header>
          <Form onSubmit={handleSubmit}>
            <Modal.Body>
              {modalType === "create" && (
                <Form.Group className="mb-3">
                  <Form.Label>Número do Quarto</Form.Label>
                  <Form.Control
                    type="number"
                    name="numQuarto"
                    value={current.numQuarto}
                    onChange={handleChange}
                    required
                  />
                </Form.Group>
              )}
              <Form.Group className="mb-3">
                <Form.Label>Camas Solteiro</Form.Label>
                <Form.Control
                  type="number"
                  name="numCamasSolteiro"
                  value={current.numCamasSolteiro}
                  onChange={handleChange}
                  required
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Camas Casal</Form.Label>
                <Form.Control
                  type="number"
                  name="numCamasCasal"
                  value={current.numCamasCasal}
                  onChange={handleChange}
                  required
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Máximo Pessoas</Form.Label>
                <Form.Control
                  type="number"
                  name="maxPessoas"
                  value={current.maxPessoas}
                  onChange={handleChange}
                  required
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Preço Diária</Form.Label>
                <Form.Control
                  type="number"
                  name="precoDiaria"
                  step="0.01"
                    value={current.precoDiaria}
                    onChange={handleChange}
                    required
                  />
                </Form.Group>
                {erroValidacao && (
                  <div className="text-danger fw-bold mt-2">{erroValidacao}</div>
                )}
              </Modal.Body>
              <Modal.Footer>
                <Button
                  variant="secondary"
                  onClick={handleClose}
                  className="bg-secondary text-white"
                >
                  Fechar
                </Button>
                <Button
                  variant="primary"
                  type="submit"
                  className="bg-primary text-white"
                >
                  {modalType === "create" ? "Cadastrar" : "Salvar"}
                </Button>
              </Modal.Footer>
            </Form>
          </Modal>

          <Modal show={showDeleteModal} onHide={() => setShowDeleteModal(false)}>
            <Modal.Header closeButton>
              <Modal.Title>Confirmar Exclusão</Modal.Title>
            </Modal.Header>
            <Modal.Body>Tem certeza que deseja excluir este quarto?</Modal.Body>
            <Modal.Footer>
              <Button
                variant="secondary"
                className="bg-secondary"
                onClick={() => setShowDeleteModal(false)}
              >
                Cancelar
              </Button>
              <Button
                variant="danger"
                className="bg-danger"
                onClick={handleDelete}
              >
                Excluir
              </Button>
            </Modal.Footer>
          </Modal>

          <Modal
            show={showPermissionModal}
            onHide={() => setShowPermissionModal(false)}
            centered
          >
            <Modal.Header closeButton>
              <Modal.Title>Acesso Restrito</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              Apenas administradores podem {nomeBtn} quartos.
            </Modal.Body>
            <Modal.Footer>
              <Button
                variant="primary"
                className="bg-primary"
                onClick={() => setShowPermissionModal(false)}
              >
                Entendi
              </Button>
            </Modal.Footer>
          </Modal>

          <Modal
            show={showBlockedModal}
            onHide={() => setShowBlockedModal(false)}
            centered
          >
            <Modal.Header closeButton>
              <Modal.Title>Ação Bloqueada</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              Este quarto está atrelado a uma reserva e não pode ser excluído.
            </Modal.Body>
            <Modal.Footer>
              <Button
                variant="primary"
                className="bg-primary"
                onClick={() => setShowBlockedModal(false)}
              >
                Entendi
              </Button>
            </Modal.Footer>
          </Modal>
        </div>
      </>
    );
}

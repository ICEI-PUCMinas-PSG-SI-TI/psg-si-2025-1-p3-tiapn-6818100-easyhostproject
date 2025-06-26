import React, { useState, useEffect } from "react";
import {
  Container,
  Table,
  Button,
  Modal,
  Form,
  Alert,
  Badge,
} from "react-bootstrap";
import Header from "./componente/Header";
import api from "../services/api";
import { jwtDecode } from "jwt-decode";

export default function Hospede() {
  const [hospedes, setHospedes] = useState([]);
  const [filtered, setFiltered] = useState([]);
  const [reservasAll, setReservasAll] = useState([]);
  const [showAddModal, setShowAddModal] = useState(false);
  const [showAddConsumoModal, setShowAddConsumoModal] = useState(false);
  const [showViewConsumosModal, setShowViewConsumosModal] = useState(false);
  const [current, setCurrent] = useState({ nome: "", cpf: "" });
  const [consumoCurrent, setConsumoCurrent] = useState({ nome: "", preco: "" });
  const [consumosList, setConsumosList] = useState([]);
  const [hotelId, setHotelId] = useState("");
  const [searchNome, setSearchNome] = useState("");
  const [message, setMessage] = useState(null);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [idToDelete, setIdToDelete] = useState(null);
  const [showDeleteConsumoModal, setShowDeleteConsumoModal] = useState(false);
  const [consumoIdToDelete, setConsumoIdToDelete] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;
    try {
      const decoded = jwtDecode(token);
      setHotelId(decoded.hotelId);
    } catch {}
  }, []);

  useEffect(() => {
    if (!hotelId) return;
    fetchHospedes();
    fetchReservas();
  }, [hotelId]);

  async function fetchHospedes() {
    try {
      const { data } = await api.get("/Hospede", { params: { hotelId } });
      setHospedes(data);
      setFiltered(data);
    } catch {
      setMessage("Erro ao buscar hóspedes");
      setTimeout(() => setMessage(null), 5000);
    }
  }

  async function fetchReservas() {
    try {
      const { data } = await api.get("/Reserva", { params: { hotelId } });
      setReservasAll(data);
    } catch {
      setReservasAll([]);
    }
  }

  useEffect(() => {
    if (!searchNome) setFiltered(hospedes);
    else
      setFiltered(
        hospedes.filter((h) =>
          h.nome.toLowerCase().includes(searchNome.toLowerCase())
        )
      );
  }, [searchNome, hospedes]);

  const handleShowAdd = () => {
    setCurrent({ nome: "", cpf: "" });
    setShowAddModal(true);
  };
  const handleCloseAdd = () => setShowAddModal(false);

  const handleShowAddConsumo = (id) => {
    setConsumoCurrent({ nome: "", preco: "" });
    setShowAddConsumoModal(true);
    setIdToDelete(id);
  };
  const handleCloseAddConsumo = () => setShowAddConsumoModal(false);

  const handleShowViewConsumos = async (id) => {
    try {
      const { data } = await api.get(`/Consumo/${id}`);
      setConsumosList(data);
      setShowViewConsumosModal(true);
    } catch {
      setMessage("Erro ao obter consumos");
      setTimeout(() => setMessage(null), 5000);
    }
  };
  const handleCloseViewConsumos = () => setShowViewConsumosModal(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    if (name === "searchNome") setSearchNome(value);
    else setCurrent((prev) => ({ ...prev, [name]: value }));
  };

  const handleChangeConsumo = (e) => {
    const { name, value } = e.target;
    setConsumoCurrent((prev) => ({ ...prev, [name]: value }));
  };

  const handleCreate = async (e) => {
    e.preventDefault();

    const cpfExistente = hospedes.some((h) => h.cpf === current.cpf);

    if (cpfExistente) {
      setMessage("Já existe um hóspede com este CPF.");
      setTimeout(() => setMessage(null), 5000);
      return;
    }

    try {
      await api.post("/Hospede/cadastrar", {
        nome: current.nome,
        cpf: current.cpf,
        hotelId,
      });
      fetchHospedes();
      handleCloseAdd();
    } catch {
      setMessage("Erro ao cadastrar hóspede");
      setTimeout(() => setMessage(null), 5000);
    }
  };
  const confirmDeleteHospede = (id) => {
    setIdToDelete(id);
    setShowDeleteModal(true);
  };

  const handleDeleteHospede = async () => {
    try {
      await api.delete(`/Hospede/${idToDelete}`);
      fetchHospedes();
      setShowDeleteModal(false);
    } catch {
      setMessage("Erro ao excluir hóspede");
      setTimeout(() => setMessage(null), 5000);
    }
  };

  const handleSubmitConsumo = async (e) => {
    e.preventDefault();
    try {
      await api.post(`/Consumo/${idToDelete}`, {
        hospedeId: idToDelete,
        nome: consumoCurrent.nome,
        preco: Number(consumoCurrent.preco),
        hotelId: hotelId,
      });
      handleCloseAddConsumo();
      setMessage("Consumo foi adicionado");
      setTimeout(() => setMessage(null), 3000);
    } catch {
      setMessage("Erro ao adicionar consumo");
      setTimeout(() => setMessage(null), 3000);
    }
  };

  const handleDeleteConsumo = async () => {
    try {
      await api.delete(`/Consumo/${consumoIdToDelete}`);
      setConsumosList((prev) => prev.filter((c) => c.id !== consumoIdToDelete));
      setShowDeleteConsumoModal(false);
      setMessage("Consumo removido");
      setTimeout(() => setMessage(null), 3000);
    } catch {
      setMessage("Erro ao remover consumo");
      setTimeout(() => setMessage(null), 3000);
    }
  };

  const formatarCPF = (cpf) => {
    if (!cpf || cpf.length !== 11) return cpf;
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
  };

  const totalConsumo = consumosList.reduce((sum, c) => sum + c.preco, 0);

  return (
    <>
      <Header />
      <Container>
        <h2>Hóspedes</h2>
        <div className="d-flex mb-3">
          <Form.Control
            type="text"
            placeholder="Buscar por nome"
            name="searchNome"
            value={searchNome}
            onChange={handleChange}
            className="mb-3 shadow"
          />
        </div>

        {message && <Alert variant="success">{message}</Alert>}

        <Button
          variant="primary"
          onClick={handleShowAdd}
          className="mb-3 bg-dark"
        >
          Novo Hóspede
        </Button>

        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Nome</th>
              <th>CPF</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {filtered.map((h) => {
              const inReserva = reservasAll.some((r) => r._hospedeId === h.id);
              return (
                <tr key={h.id}>
                  <td>{h.nome}</td>
                  <td>{formatarCPF(h.cpf)}</td>
                  <td>
                    <Button
                      size="sm"
                      variant="success"
                      onClick={() => handleShowAddConsumo(h.id)}
                      className="me-2 bg-success"
                    >
                      Add Consumo
                    </Button>
                    <Button
                      size="sm"
                      variant="info"
                      onClick={() => handleShowViewConsumos(h.id)}
                      className="me-2 bg-primary text-white"
                    >
                      Ver Consumo
                    </Button>
                    <Button
                      size="sm"
                      variant="danger"
                      onClick={() => confirmDeleteHospede(h.id)}
                      disabled={inReserva}
                      className="bg-danger"
                    >
                      Excluir
                    </Button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </Table>

        <Modal show={showAddModal} onHide={handleCloseAdd}>
          <Modal.Header closeButton>
            <Modal.Title>Novo Hóspede</Modal.Title>
          </Modal.Header>
          <Form onSubmit={handleCreate}>
            <Modal.Body>
              <Form.Group className="mb-3">
                <Form.Label>Nome</Form.Label>
                <Form.Control
                  type="text"
                  name="nome"
                  value={current.nome}
                  onChange={handleChange}
                  required
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>CPF</Form.Label>
                <Form.Control
                  type="text"
                  name="cpf"
                  maxLength={11}
                  pattern="\d{11}"
                  value={current.cpf}
                  onChange={handleChange}
                  required
                />
              </Form.Group>
            </Modal.Body>
            <Modal.Footer>
              <Button
                variant="secondary"
                className="bg-secondary"
                onClick={handleCloseAdd}
              >
                Cancelar
              </Button>
              <Button variant="primary" className="bg-primary" type="submit">
                Cadastrar
              </Button>
            </Modal.Footer>
          </Form>
        </Modal>

        <Modal show={showAddConsumoModal} onHide={handleCloseAddConsumo}>
          <Modal.Header closeButton>
            <Modal.Title>Adicionar Consumo</Modal.Title>
          </Modal.Header>
          <Form onSubmit={handleSubmitConsumo}>
            <Modal.Body>
              <Form.Group className="mb-3">
                <Form.Label>Nome Consumo</Form.Label>
                <Form.Control
                  type="text"
                  name="nome"
                  value={consumoCurrent.nome}
                  onChange={handleChangeConsumo}
                  required
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Preço</Form.Label>
                <Form.Control
                  type="number"
                  name="preco"
                  step="0.01"
                  value={consumoCurrent.preco}
                  onChange={handleChangeConsumo}
                  required
                />
              </Form.Group>
            </Modal.Body>
            <Modal.Footer>
              <Button
                variant="secondary"
                className="bg-secondary"
                onClick={handleCloseAddConsumo}
              >
                Cancelar
              </Button>
              <Button variant="success" className="bg-success" type="submit">
                Adicionar
              </Button>
            </Modal.Footer>
          </Form>
        </Modal>

        <Modal show={showViewConsumosModal} onHide={handleCloseViewConsumos}>
          <Modal.Header closeButton>
            <Modal.Title>Consumos do Hóspede</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Table striped>
              <thead>
                <tr>
                  <th>Nome</th>
                  <th>Preço (R$)</th>
                  <th>Ações</th>
                </tr>
              </thead>
              <tbody>
                {consumosList.map((c, idx) => (
                  <tr key={idx}>
                    <td>{c.nome}</td>
                    <td>{c.preco.toFixed(2)}</td>
                    <td>
                      <Button
                        variant="danger"
                        size="sm"
                        className="bg-danger"
                        onClick={() => {
                          setConsumoIdToDelete(c.id);
                          setShowDeleteConsumoModal(true);
                        }}
                      >
                        Excluir
                      </Button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
            <div className="mt-3">
              <strong>Total: R$ {totalConsumo.toFixed(2)}</strong>
            </div>
          </Modal.Body>
          <Modal.Footer>
            <Button
              variant="secondary"
              className="bg-secondary"
              onClick={handleCloseViewConsumos}
            >
              Fechar
            </Button>
          </Modal.Footer>
        </Modal>

        <Modal show={showDeleteModal} onHide={() => setShowDeleteModal(false)}>
          <Modal.Header closeButton>
            <Modal.Title>Confirmar Exclusão</Modal.Title>
          </Modal.Header>
          <Modal.Body>Tem certeza que deseja excluir este hóspede?</Modal.Body>
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
              onClick={handleDeleteHospede}
            >
              Excluir
            </Button>
          </Modal.Footer>
        </Modal>

        <Modal
          show={showDeleteConsumoModal}
          onHide={() => setShowDeleteConsumoModal(false)}
        >
          <Modal.Header closeButton>
            <Modal.Title>Confirmar Exclusão</Modal.Title>
          </Modal.Header>
          <Modal.Body>Tem certeza que deseja excluir este consumo?</Modal.Body>
          <Modal.Footer>
            <Button
              variant="secondary"
              className="bg-secondary"
              onClick={() => setShowDeleteConsumoModal(false)}
            >
              Cancelar
            </Button>
            <Button
              variant="danger"
              className="bg-danger"
              onClick={handleDeleteConsumo}
            >
              Excluir
            </Button>
          </Modal.Footer>
        </Modal>
      </Container>
    </>
  );
}

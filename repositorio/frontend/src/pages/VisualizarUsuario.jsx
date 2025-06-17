import React, { useState, useEffect } from "react";
import { Container, Row, Col, Button, Modal, Form } from "react-bootstrap";
import Header from "./componente/Header";
import api from "../services/api";
import { jwtDecode } from "jwt-decode";

export default function VisualizarUsuario() {
  const [usuario, setUsuario] = useState(null);
  const [hotelName, setHotelName] = useState("");
  const [userId, setUserId] = useState("");
  const [tipoUsuario, setTipoUsuario] = useState(1);
  const [showEditModal, setShowEditModal] = useState(false);
  const [showConfirmDeactivate, setShowConfirmDeactivate] = useState(false);
  const [formState, setFormState] = useState({
    nome: "",
    salario: 0,
    tipoUsuario: 1,
    ativo: true,
  });

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;
    try {
      const decoded = jwtDecode(token);
      setUserId(decoded.userId);
      setTipoUsuario(decoded.tipoUsuario === "Funcionario" ? 1 : 2);
      if (decoded.hotelId) {
        api
          .get(`/Hotel/${decoded.hotelId}`)
          .then(({ data }) => setHotelName(data.nomeHotel));
      }
      api
        .get("/Usuario", { params: { email: decoded.email } })
        .then(({ data }) => setUsuario(data));
    } catch {}
  }, []);

  const abrirModal = () => {
    if (!usuario) return;
    setFormState({
      nome: usuario._nome,
      salario: usuario._salario,
      tipoUsuario: tipoUsuario,
      ativo: usuario._ativo,
    });
    setShowEditModal(true);
  };

  const logout = () => {
    localStorage.removeItem("token");
    window.location.href = "/login";
  };

  const handleChange = (field, value) => {
    if (field === "ativo" && formState.ativo && !value) {
      setShowConfirmDeactivate(true);
    } else {
      setFormState((s) => ({ ...s, [field]: value }));
    }
  };

  const confirmarDesativacao = () => {
    setFormState((s) => ({ ...s, ativo: false }));
    setShowConfirmDeactivate(false);
  };
  const cancelarDesativacao = () => setShowConfirmDeactivate(false);

  const salvar = () => {
    const payload = {
      id: userId,
      nome: formState.nome,
      salario: formState.salario,
      tipoUsuario: formState.tipoUsuario,
      ativo: formState.ativo,
    };
    api.put("/Usuario/Atualizar", payload).then(({ data }) => {
      setUsuario({
        ...usuario,
        _id: data.id || usuario._id,
        _nome: data.nome,
        _salario: data.salario,
        _tipoUsuario: data.tipoUsuario,
        _ativo: data.ativo,
      });
      setShowEditModal(false);
      window.location.reload();
    });
  };

  if (!usuario) return null;

  return (
    <>
      <Header />

      <Container fluid className="py-5 bg-light">
        <Container className="py-5 bg-white rounded-4 shadow-lg">
          <h3>Meus Dados</h3>

          <Row className="gx-0 gy-3">
            <Col xs={6}>
              <strong>Nome:</strong> {usuario._nome}
            </Col>
            <Col xs={6}>
              <strong>CPF:</strong> {usuario._cpf}
            </Col>
            <Col xs={6}>
              <strong>Salário:</strong>{" "}
              {typeof usuario._salario === "number"
                ? usuario._salario.toLocaleString("pt-BR", {
                    style: "currency",
                    currency: "BRL",
                  })
                : "—"}
            </Col>
            <Col xs={6}>
              <strong>Ativo:</strong> {usuario._ativo ? "Sim" : "Não"}
            </Col>
            <Col xs={6}>
              <strong>Tipo de Usuário:</strong>{" "}
              {usuario._tipoUsuario === 2 ? "Administrador" : "Funcionário"}
            </Col>
            <Col xs={6}>
              <strong>Hotel:</strong> {hotelName}
            </Col>
          </Row>

          <div className="d-flex justify-content-end mt-4 gap-2">
            <Button
              variant="danger"
              className="bg-danger"
              onClick={logout}
            >
              Deslogar
            </Button>
                        <Button
              variant="primary"
              className="bg-primary"
              onClick={abrirModal}
            >
              Atualizar
            </Button>
          </div>
        </Container>
      </Container>

      <Modal show={showEditModal} onHide={() => setShowEditModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Atualizar Dados</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form.Group as={Row} className="mb-3">
            <Form.Label column sm={4}>
              Nome:
            </Form.Label>
            <Col sm={8}>
              <Form.Control
                type="text"
                value={formState.nome}
                onChange={(e) => handleChange("nome", e.target.value)}
              />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="mb-3">
            <Form.Label column sm={4}>
              Salário:
            </Form.Label>
            <Col sm={8}>
              <Form.Control
                type="number"
                value={formState.salario}
                onChange={(e) =>
                  handleChange("salario", parseFloat(e.target.value))
                }
              />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="mb-3">
            <Form.Label column sm={4}>
              Ativo:
            </Form.Label>
            <Col sm={8}>
              <Form.Check
                style={{ marginTop: "0.4rem" }}
                checked={formState.ativo}
                onChange={(e) => handleChange("ativo", e.target.checked)}
              />
            </Col>
          </Form.Group>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            className="bg-secondary"
            onClick={() => setShowEditModal(false)}
          >
            Cancelar
          </Button>
          <Button variant="primary" className="bg-primary" onClick={salvar}>
            Salvar
          </Button>
        </Modal.Footer>
      </Modal>

      <Modal show={showConfirmDeactivate} onHide={cancelarDesativacao}>
        <Modal.Header closeButton>
          <Modal.Title>Confirmar Desativação</Modal.Title>
        </Modal.Header>
        <Modal.Body>Confirmar desativação do perfil?</Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            className="bg-secondary"
            onClick={cancelarDesativacao}
          >
            Não
          </Button>
          <Button
            variant="danger"
            className="bg-danger"
            onClick={confirmarDesativacao}
          >
            Sim
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

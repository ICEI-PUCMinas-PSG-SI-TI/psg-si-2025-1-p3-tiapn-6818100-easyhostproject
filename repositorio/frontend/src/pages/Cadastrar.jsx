import React, { useState, useEffect } from "react";
import { Container, Card, Form, Button, Spinner } from "react-bootstrap";
import { FaHotel } from "react-icons/fa";
import api from "../services/api";

export default function Cadastrar() {
  const [form, setForm] = useState({
    nome: "",
    cpf: "",
    salario: "",
    tipoUsuario: "1",
    email: "",
    senha: "",
    confirmSenha: "",
    hotelId: "",
  });
  const [hotels, setHotels] = useState([]);
  const [loadingHotels, setLoadingHotels] = useState(true);
  const [submitting, setSubmitting] = useState(false);
  const [message, setMessage] = useState(null);

  useEffect(() => {
    api
      .get("/hotel/GetAll")
      .then((res) => setHotels(res.data))
      .catch(() => setMessage("Falha ao carregar hotéis"))
      .finally(() => setLoadingHotels(false));
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm((f) => ({ ...f, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (form.senha !== form.confirmSenha) {
      setMessage("As senhas não conferem");
      return;
    }
    setSubmitting(true);
    setMessage(null);

    const { confirmSenha, tipoUsuario, ...rest } = form;
    const payload = {
      ...rest,
      tipoUsuario: Number(tipoUsuario),
    };

    try {
      await api.post("/Usuario/cadastrar", payload);
      setMessage("Usuário cadastrado com sucesso!");
      setForm({
        nome: "",
        cpf: "",
        salario: "",
        tipoUsuario: "1",
        email: "",
        senha: "",
        confirmSenha: "",
        hotelId: "",
      });
      window.location.href = "/login";
    } catch (err) {
      setMessage(err.response?.data?.error || "Erro ao cadastrar");
    } finally {
      setSubmitting(false);
    }
  };

  const formatCurrency = (value) => {
    if (!value) return "";
    const number = Number(value.toString().replace(/\D/g, "")) / 100;
    return number.toLocaleString("pt-BR", {
      style: "currency",
      currency: "BRL",
      minimumFractionDigits: 2,
    });
  };

  const handleSalarioChange = (e) => {
    const rawValue = e.target.value.replace(/\D/g, "");
    setForm((f) => ({
      ...f,
      salario: rawValue,
    }));
  };

  return (
    <>
      <Container
        fluid
        className="bg-dark min-vh-100 d-flex align-items-center justify-content-center"
      >
        <Card bg="dark" text="white" className="rounded-4 shadow-lg p-4 w-25">
          <Card.Body className="text-center">
            <a href="/">
              <FaHotel size={48} className="mb-3" />
            </a>
            <Card.Title as="h2" className="mb-4">
              Cadastro de Usuário
            </Card.Title>

            {message && (
              <div
                className={
                  "alert " +
                  (message.includes("sucesso")
                    ? "alert-success"
                    : "alert-danger")
                }
              >
                {message}
              </div>
            )}

            <Form onSubmit={handleSubmit}>
              <Form.Control
                name="nome"
                value={form.nome}
                onChange={handleChange}
                placeholder="Nome Completo"
                className="placeholder-white bg-secondary bg-opacity-10 border-0 rounded-pill px-3 py-2 text-white mb-3"
                required
              />

              <Form.Control
                name="cpf"
                value={form.cpf}
                onChange={handleChange}
                maxLength={11}
                pattern="\d{11}"
                placeholder="CPF"
                className="placeholder-white bg-secondary bg-opacity-10 border-0 rounded-pill px-3 py-2 text-white mb-3"
                required
              />

              <Form.Control
                name="salario"
                value={formatCurrency(form.salario)}
                onChange={handleSalarioChange}
                placeholder="Salário"
                className="placeholder-white bg-secondary bg-opacity-10 border-0 rounded-pill px-3 py-2 text-white mb-3"
                required
                inputMode="numeric"
                autoComplete="off"
              />

              <Form.Select
                name="tipoUsuario"
                value={form.tipoUsuario}
                onChange={handleChange}
                className="bg-secondary border-0 rounded-pill px-3 py-2 text-white mb-3"
                required
              >
                <option value="1">Funcionário</option>
                <option value="2">Administrador</option>
              </Form.Select>

              <Form.Control
                type="email"
                name="email"
                value={form.email}
                onChange={handleChange}
                placeholder="E-mail"
                className="placeholder-white bg-secondary bg-opacity-10 border-0 rounded-pill px-3 py-2 text-white mb-3"
                required
              />

              <Form.Control
                type="password"
                name="senha"
                value={form.senha}
                onChange={handleChange}
                placeholder="Senha"
                className="placeholder-white bg-secondary bg-opacity-10 border-0 rounded-pill px-3 py-2 text-white mb-3"
                required
              />

              <Form.Control
                type="password"
                name="confirmSenha"
                value={form.confirmSenha}
                onChange={handleChange}
                placeholder="Confirmar senha"
                className="placeholder-white bg-secondary bg-opacity-10 border-0 rounded-pill px-3 py-2 text-white mb-3"
                required
              />

              <Form.Group className="mb-4">
                {loadingHotels ? (
                  <Spinner
                    animation="border"
                    size="sm"
                    className="text-light"
                  />
                ) : (
                  <Form.Select
                    name="hotelId"
                    value={form.hotelId}
                    onChange={handleChange}
                    className="bg-secondary border-0 rounded-pill px-3 py-2 text-white"
                    required
                  >
                    <option value="" disabled>
                      Selecione um hotel
                    </option>
                    {hotels.map((h) => (
                      <option key={h.id} value={h.id}>
                        {h.nomeHotel}
                      </option>
                    ))}
                  </Form.Select>
                )}
              </Form.Group>

              <Button
                type="submit"
                variant="primary"
                className="w-100 rounded-pill py-2 border mb-3"
                disabled={submitting}
              >
                {submitting ? (
                  <>
                    <Spinner animation="border" size="sm" /> Cadastrando...
                  </>
                ) : (
                  "Cadastrar"
                )}
              </Button>
              <Button
                variant="outline-light"
                className="w-100 rounded-pill py-2 text-white bg-transparent"
                onClick={() => (window.location.href = "/login")}
              >
                Login
              </Button>
            </Form>
          </Card.Body>
        </Card>
      </Container>
    </>
  );
}

import React, { useState, useEffect } from "react";
import { Container, Form, Button, Table, Alert } from "react-bootstrap";
import api from "../services/api";
import { jwtDecode } from "jwt-decode";
import Header from "./componente/Header";

export default function CriarReserva() {
  const [hotelId, setHotelId] = useState("");
  const [cpf, setCpf] = useState("");
  const [hospede, setHospede] = useState(null);
  const [erroHospede, setErroHospede] = useState("");
  const [entrada, setEntrada] = useState("");
  const [saida, setSaida] = useState("");
  const [quartos, setQuartos] = useState([]);
  const [quartoId, setQuartoId] = useState("");
  const [mensagem, setMensagem] = useState("");
  const [erroData, setErroData] = useState("");
  const [quartoIndisponivel, setQuartoIndisponivel] = useState("");
  
  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      try {
        const decoded = jwtDecode(token);
        setHotelId(decoded.hotelId);
      } catch {}
    }
  }, []);

  const buscarHospede = async () => {
    try {
      const { data } = await api.get(`/Hospede/cpf/${cpf}`);
      setHospede(data);
    } catch {
      setHospede(null);
      setErroHospede("Hóspede não encontrado");
      setTimeout(() => setErroHospede(""), 3000);
    }
  };

  const buscarQuartos = async () => {
    try {
      const { data } = await api.get("/Quarto/disponiveis", {
        params: { dataInicial: entrada, hotelId },
      });
      if (data.length === 0) {
        setQuartoIndisponivel("Não há quartos disponíveis para as datas selecionadas.");
        setTimeout(() => setQuartoIndisponivel(""), 3000);
      }
      setQuartos(data);
    } catch {
      setQuartos([]);
    }
  };

  const criarReserva = async () => {
    if (!validarDatas()) return;
    try {
      await api.post("/Reserva/cadastrar", {
        _hospedeId: hospede.id,
        _quartoId: quartoId,
        _hotelId: hotelId,
        _dataEntrada: entrada,
        _dataSaida: saida,
      });
      setMensagem("Reserva criada com sucesso");
      setTimeout(() => setMensagem(""), 3000);
      setCpf("");
      setHospede(null);
      setEntrada("");
      setSaida("");
      setQuartos([]);
      setQuartoId("");
    } catch {
      setMensagem("Erro ao criar reserva");
      setTimeout(() => setMensagem(""), 3000);
    }
  };

  const validarDatas = () => {
    if (!entrada || !saida) return false;
    const dataEntrada = new Date(entrada);
    const dataSaida = new Date(saida);
    if (dataSaida <= dataEntrada) {
      setErroData("A data de saída deve ser posterior à data de entrada.");
      return false;
    }
    setErroData("");
    return true;
  };

  return (
    <>
      <Header />
      <Container className="py-4">
        <div className="d-flex justify-content-between align-items-center mb-3">
          <h3>Criar Reserva</h3>
          <Button
            variant="primary"
            className="bg-primary"
            onClick={() => (window.location.href = "/reserva/lista")}
          >
            Ver Reservas
          </Button>
        </div>

        {mensagem && <Alert variant="success">{mensagem}</Alert>}

        <div className="d-flex w-100 gap-3">
          <Form.Group className="mb-3 flex-fill">
            <Form.Label>CPF do Hóspede</Form.Label>
            <div className="input-group-append">
              <Form.Control
                type="text"
                value={cpf}
                maxLength={11} pattern="\d{11}" 
                onChange={(e) => setCpf(e.target.value)}
                placeholder="Digite CPF"
              />
              <div className="gap-2 d-flex mt-3">
                <Button className="bg-primary" onClick={buscarHospede}>
                  Buscar Hóspede
                </Button>
                <Button
                  className="bg-primary"
                  onClick={() => (window.location.href = "/hospede")}
                >
                  Criar Hóspede
                </Button>
              </div>
            </div>
            {erroHospede && (
              <Alert variant="danger" className="mt-2">
                {erroHospede}
              </Alert>
            )}
          </Form.Group>
          <Form.Group className="mb-3 flex-fill">
            <Form.Label>Nome do Hóspede</Form.Label>
            <Form.Control
              type="text"
              readOnly
              value={hospede?.nome || ""}
              style={{ backgroundColor: "rgba(206, 206, 206, 0.46)" }}
            />
          </Form.Group>
        </div>

        <div className="d-flex w-100 gap-3 mt-3">
          <Form.Group>
            <Form.Label>Data de Entrada</Form.Label>
            <Form.Control
              type="date"
              value={entrada}
              onChange={(e) => setEntrada(e.target.value)}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Data de Saída</Form.Label>
            <Form.Control
              type="date"
              value={saida}
              onChange={(e) => setSaida(e.target.value)}
            />
          </Form.Group>
        </div>

        <div>
          {erroData && (
            <Alert variant="danger" className="mt-2">
              {erroData}
            </Alert>
          )}
        </div>
        <div style={{ marginTop: "20px" }}>
          <Button
            className="bg-primary mb-3 me-3"
            onClick={buscarQuartos}
            disabled={!entrada || !saida}
          >
            Quartos Disponíveis
          </Button>
          {quartos.length > 0 && (
            <Form.Group className="mb-3">
              <Form.Label>Selecione um Quarto</Form.Label>
              <Form.Select
                value={quartoId}
                onChange={(e) => setQuartoId(e.target.value)}
              >
                <option value="">-- Escolha um quarto --</option>
                {quartos.map((q) => (
                  <option key={q.id} value={q.id}>
                    {q.numQuarto || q.id}
                  </option>
                ))}
              </Form.Select>
            </Form.Group>
          )}
          <Button
            onClick={criarReserva}
            disabled={!quartoId}
            className="bg-primary mb-3"
          >
            Criar Reserva
          </Button>
        </div>
         {quartoIndisponivel && <Alert variant="danger">{quartoIndisponivel}</Alert>}
      </Container>
    </>
  );
}

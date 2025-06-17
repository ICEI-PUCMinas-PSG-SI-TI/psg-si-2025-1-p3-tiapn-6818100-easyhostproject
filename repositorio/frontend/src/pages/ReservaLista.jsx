import React, { useState, useEffect } from 'react';
import { Container, Table, Button, Modal, Form } from 'react-bootstrap';
import Header from './componente/Header';
import api from '../services/api';
import { jwtDecode } from 'jwt-decode';

export default function ReservasLista() {
  const [hotelId, setHotelId] = useState('');
  const [reservas, setReservas] = useState([]);
  const [filtro, setFiltro] = useState('');
  const [hospedesMap, setHospedesMap] = useState({});
  const [quartosMap, setQuartosMap] = useState({});

  const [showCancelModal, setShowCancelModal] = useState(false);
  const [showConsumoModal, setShowConsumoModal] = useState(false);
  const [selectedReservaId, setSelectedReservaId] = useState(null);
  const [consumo, setConsumo] = useState(null);

  const statusOptions = [
    { value: 1, label: 'Reservada',  color: 'table-primary' },
    { value: 2, label: 'Confirmada', color: 'table-info' },
    { value: 3, label: 'Andamento',  color: 'table-warning' },
    { value: 4, label: 'Concluída',  color: 'table-success' },
    { value: 5, label: 'Cancelada',  color: 'table-danger' }
  ];

  const statusClassMap = statusOptions.reduce((m, s) => {
    m[s.value] = s.color;
    return m;
  }, {});

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      try {
        const decoded = jwtDecode(token);
        setHotelId(decoded.hotelId);
      } catch {}
    }
  }, []);

  useEffect(() => {
    if (!hotelId) return;
    api.get('/Reserva', { params: { hotelId, dataInicial: filtro } })
      .then(({ data }) => setReservas(data))
      .catch(() => setReservas([]));
  }, [hotelId, filtro]);

  useEffect(() => {
    const hospedeIds = [...new Set(reservas.map(r => r._hospedeId))];
    hospedeIds.forEach(id => {
      if (!hospedesMap[id]) {
        api.get(`/Hospede/${id}`)
          .then(({ data }) => setHospedesMap(m => ({ ...m, [id]: data.nome })))
          .catch(() => {});
      }
    });
    const quartoIds = [...new Set(reservas.map(r => r._quartoId))];
    quartoIds.forEach(id => {
      if (!quartosMap[id]) {
        api.get(`/Quarto/${id}`)
          .then(({ data }) => setQuartosMap(q => ({ ...q, [id]: data.numQuarto })))
          .catch(() => {});
      }
    });
  }, [reservas]);

  const alterarStatus = (id, novoStatus) => {
    api.put('/Reserva/alterar', { _id: id, _statusReserva: novoStatus })
      .then(() => setReservas(r => r.map(x => x._id === id ? { ...x, _statusReserva: novoStatus } : x)));
  };

  const abrirConfirmacaoCancelamento = id => {
    setSelectedReservaId(id);
    setShowCancelModal(true);
  };

  const confirmarCancelamento = () => {
    api.delete(`/Reserva/cancelar/${selectedReservaId}`)
      .then(() => {
        setReservas(r => r.filter(x => x._id !== selectedReservaId));
        setShowCancelModal(false);
        setSelectedReservaId(null);
      });
  };

  const verConsumo = id => {
    setSelectedReservaId(id);
    api.get(`/Reserva/calcular-preco/${id}`)
      .then(({ data }) => {
        setConsumo(data.toFixed(2));
        setShowConsumoModal(true);
      });
  };

  return (
    <>
      <Header />
      <Container className="py-4">
        <div className="d-flex justify-content-between align-items-center mb-3">
          <h3>Minhas Reservas</h3>
          <Button
            variant="primary"
            className="bg-primary"
            onClick={() => window.location.href = '/reserva/create'}
          >
            Criar Reserva
          </Button>
        </div>

        <Form.Group className="mb-3">
          <Form.Label>Filtrar por Data de Entrada</Form.Label>
          <Form.Control
            type="date"
            value={filtro}
            onChange={e => setFiltro(e.target.value)}
          />
        </Form.Group>

        <Table bordered hover>
          <thead>
            <tr>
              <th>Hóspede Responsável</th>
              <th>Numero do Quarto</th>
              <th>Entrada</th>
              <th>Saída</th>
              <th>Status</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {reservas.map(r => (
              <tr
                key={r._id}
                className={statusClassMap[r._statusReserva] || ''}
              >
                <td>{hospedesMap[r._hospedeId] || r._hospedeId}</td>
                <td>{quartosMap[r._quartoId] || r._quartoId}</td>
                <td>{new Date(r._dataEntrada).toLocaleDateString()}</td>
                <td>{new Date(r._dataSaida).toLocaleDateString()}</td>
                <td>
                  <Form.Select
                    value={r._statusReserva}
                    onChange={e => alterarStatus(r._id, Number(e.target.value))}
                    className="text-dark"
                  >
                    {statusOptions.map(s => (
                      <option key={s.value} value={s.value}>
                        {s.label}
                      </option>
                    ))}
                  </Form.Select>
                </td>
                <td className="d-flex gap-2">
                  <Button
                    size="sm"
                    variant="danger"
                    className="bg-danger"
                    onClick={() => abrirConfirmacaoCancelamento(r._id)}
                  >
                    Excluir
                  </Button>
                  <Button
                    size="sm"
                    variant="primary"
                    className="bg-primary"
                    onClick={() => verConsumo(r._id)}
                  >
                    Consumo
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Container>

      <Modal show={showCancelModal} onHide={() => setShowCancelModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Confirmar Cancelamento</Modal.Title>
        </Modal.Header>
        <Modal.Body>Deseja realmente cancelar esta reserva?</Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            className="bg-secondary"
            onClick={() => setShowCancelModal(false)}
          >
            Fechar
          </Button>
          <Button
            variant="danger"
            className="bg-danger"
            onClick={confirmarCancelamento}
          >
            Confirmar
          </Button>
        </Modal.Footer>
      </Modal>

      <Modal show={showConsumoModal} onHide={() => setShowConsumoModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Consumo Total</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {consumo !== null ? `Consumo total: R$ ${consumo}` : 'Carregando...'}
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="primary"
            className="bg-primary"
            onClick={() => setShowConsumoModal(false)}
          >
            Fechar
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

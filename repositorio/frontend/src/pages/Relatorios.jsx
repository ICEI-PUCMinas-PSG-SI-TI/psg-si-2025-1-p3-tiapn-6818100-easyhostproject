import React, { useEffect, useState } from 'react'
import { jwtDecode } from 'jwt-decode'
import api from '../services/api'
import Header from './componente/Header'
import { Container, Row, Col, Card } from 'react-bootstrap'
import { Pie, Bar } from 'react-chartjs-2'
import { Chart as ChartJS, ArcElement, Tooltip, Legend, CategoryScale, LinearScale, BarElement} from 'chart.js'
ChartJS.register(ArcElement, Tooltip, Legend, CategoryScale, LinearScale, BarElement)


export default function Relatorios() {
  const [userName, setUserName] = useState('')
  const [hotelId, setHotelId] = useState('')
  const [hotelName, setHotelName] = useState('')
  const [consumos, setConsumos] = useState([])
  const [tempoMedio, setTempoMedio] = useState(null)

useEffect(() => {
    const token = localStorage.getItem('token')
    if (!token) return

    try {
      const decoded = jwtDecode(token)
      setUserName(decoded.name || '')
      if (decoded.hotelId) {
        setHotelId(decoded.hotelId)
        api
          .get(`/Hotel/${decoded.hotelId}`)
          .then(({ data }) => setHotelName(data.nomeHotel))
          .catch(err => console.error('Erro ao buscar hotel:', err))
      }
    } catch (err) {
      console.error('Erro ao decodificar token:', err)
    }
  }, [])

  useEffect(() => {
    if (!hotelId) return

    api
      .get(`Consumo/consumoFrequencia/${hotelId}`)
      .then(({ data }) => setConsumos(data))
      .catch(err => console.error('Erro ao buscar consumos:', err))

    api
      .get(`Reserva/tempo-medio/${hotelId}`)
      .then(({ data }) => setTempoMedio(data))
      .catch(err => console.error('Erro ao buscar tempo médio:', err))
  }, [hotelId])

  const pizzaData = {
    labels: consumos.map(c => c.nome),
    datasets: [
      {
        data: consumos.map(c => c.quantidade),
        backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0', '#9966FF', '#FF9F40'],
        borderWidth: 1,
      },
    ],
  }

  const barraData = {
    labels: ['Tempo médio de estadia (dias)'],
    datasets: [
      {
        label: 'Dias',
        data: tempoMedio ? [tempoMedio] : [0],
        backgroundColor: ['#36A2EB'],
      },
    ],
  }

  return (
    <>
      <Header />

      <Container className="mt-5">
        <Row className="mb-4 justify-content-between align-items-center">
          <Col>
            <h3>Relatórios do Hotel</h3>
          </Col>
          {hotelName && (
            <Col className="text-end text-uppercase text-primary">
              <h5>{hotelName}</h5>
            </Col>
          )}
        </Row>

        <Row className="mb-5">
          <Col md={6} className="mb-4">
            <Card className="shadow rounded-4">
              <Card.Body>
                <Card.Title className="text-center">Consumos Mais Frequentes</Card.Title>
                <Pie data={pizzaData} />
              </Card.Body>
            </Card>
          </Col>

          <Col md={6}>
            <Card className="shadow rounded-4">
              <Card.Body>
                <Card.Title className="text-center">Tempo Médio de Estadia</Card.Title>
                <Bar data={barraData} options={{ scales: { y: { beginAtZero: true } } }} />
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </>
  )
}
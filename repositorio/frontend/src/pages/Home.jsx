import React, { useEffect, useState } from 'react'
import { jwtDecode } from 'jwt-decode'
import Header from './componente/Header'
import api from '../services/api'
import { Container, Row, Col, Card } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import reservaImg from '../images/reservaImg.png'
import quartoImg from '../images/quartoImg.png'
import hospedeImg from '../images/hospedeImg.png'



const cardConfig = [
  {
    title: 'Hóspede',
    text: 'Gerencie hóspedes cadastrados no sistema.',
    imgSrc: hospedeImg,
    link: '/hospede',
  },
  {
    title: 'Quarto',
    text: 'Visualize e cadastre quartos disponíveis.',
    imgSrc: quartoImg,
    link: '/quarto',
  },
  {
    title: 'Reservas',
    text: 'Acesse a lista de reservas ou crie uma nova.',
    imgSrc: reservaImg,
    link: '/reserva/lista',
  },
]

function CardItem({ title, text, imgSrc, link }) {
  const [hover, setHover] = useState(false)

  return (
    <Link to={link} className="text-decoration-none d-block">
      <Card
        onMouseEnter={() => setHover(true)}
        onMouseLeave={() => setHover(false)}
        className="rounded-4 shadow-lg mb-4 mx-auto"
        style={{
          width: '22rem',
          transform: hover ? 'scale(1.03)' : 'scale(1)',
          transition: 'transform 0.2s ease',
        }}
      >
        {imgSrc && (
          <Card.Img
            variant="top"
            src={imgSrc}
            alt={title}
            style={{ height: '20rem', objectFit: 'cover' }}
          />
        )}
        <Card.Body>
          <Card.Title>{title}</Card.Title>
          <Card.Text>{text}</Card.Text>
        </Card.Body>
      </Card>
    </Link>
  )
}

export default function Home() {
  const [userName, setUserName] = useState('')
  const [hotelName, setHotelName] = useState('')

  useEffect(() => {
    const token = localStorage.getItem('token')
    if (!token) return

    try {
      const decoded = jwtDecode(token)
      setUserName(decoded.name || '')
      if (decoded.hotelId) {
        api
          .get(`/Hotel/${decoded.hotelId}`)
          .then(({ data }) => setHotelName(data.nomeHotel))
          .catch(err => console.error('Erro ao buscar hotel:', err))
      }
    } catch (err) {
      console.error('Erro ao decodificar token:', err)
    }
  }, [])

  return (
    <>
      <Header />

      <Container className="mt-5">
        <Row className="mb-4 justify-content-between align-items-center">
          <Col>
            <h3>Olá, {userName || 'Bem-vindo ao EasyHost'}</h3>
          </Col>
          {hotelName && (
            <Col className="text-end text-uppercase text-primary">
              <h5>{hotelName}</h5>
            </Col>
          )}
        </Row>

        <Row>
          {cardConfig.map(cfg => (
            <Col key={cfg.title} md={4}>
              <CardItem {...cfg} />
            </Col>
          ))}
        </Row>
      </Container>
    </>
  )
}

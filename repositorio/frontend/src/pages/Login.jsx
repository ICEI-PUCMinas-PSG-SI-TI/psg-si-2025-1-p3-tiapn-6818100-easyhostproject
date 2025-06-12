import React, { useState } from 'react'
import { Container, Card, Form, Button, Spinner } from 'react-bootstrap'
import { FaSignInAlt } from 'react-icons/fa'
import api from '../services/api'

export default function Login() {
  const [form, setForm] = useState({ email: '', senha: '' })
  const [submitting, setSubmitting] = useState(false)
  const [message, setMessage] = useState(null)

  const handleChange = e => {
    const { name, value } = e.target
    setForm(prev => ({ ...prev, [name]: value }))
  }

  const handleSubmit = async e => {
    e.preventDefault()
    setSubmitting(true)
    setMessage(null)

    try {
      const { data } = await api.post('/Usuario/login', form)
      const { token } = data
      localStorage.setItem('token', token)
      api.defaults.headers.common['Authorization'] = `Bearer ${token}`
      window.location.href = '/'
    } catch (err) {
      setMessage(err.response?.data?.error || 'Falha no login')
    } finally {
      setSubmitting(false)
    }
  }

  return (
    <Container
      fluid
      className="bg-dark min-vh-100 d-flex align-items-center justify-content-center"
    >
      <Card
        bg="dark"
        text="white"
        className="rounded-4 shadow-lg p-4"
        style={{ maxWidth: 380, width: '90%' }}
      >
        <Card.Body className="text-center">
          <a href="/"><FaSignInAlt size={48} className="mb-3" /></a>
          <Card.Title as="h2" className="mb-4">Login</Card.Title>

          {message && (
            <div className={`alert ${message.includes('sucesso') ? 'alert-success' : 'alert-danger'}`}>
              {message}
            </div>
          )}

          <Form onSubmit={handleSubmit}>
            <Form.Control
              type="email"
              name="email"
              value={form.email}
              onChange={handleChange}
              placeholder="E-mail"
              className="placeholder-white bg-secondary bg-opacity-10 border-0 rounded-pill px-3 py-2 text-white mb-3"
              required
            />

            <Form.Group className="mb-4 position-relative">
              <Form.Control
                type="password"
                name="senha"
                value={form.senha}
                onChange={handleChange}
                placeholder="Senha"
                className="placeholder-white bg-secondary bg-opacity-10 border-0 rounded-pill px-3 py-2 text-white"
                required
              />
              <Button
                variant="link"
                className="position-absolute top-0 end-0 p-0 text-info"
                style={{ margin: '0.75rem', fontSize: '12px' }}
                onClick={() => window.location.href = '/mudar-senha'}
              >
                Esqueceu?
              </Button>
            </Form.Group>

            <Button
              type="submit"
              variant="primary"
              className="w-100 rounded-pill py-2 mb-2 border"
              disabled={submitting}
            >
              {submitting
                ? <><Spinner animation="border" size="sm" /> Entrando...</>
                : 'Entrar'
              }
            </Button>

            <Button
              variant="outline-light"
              className="w-100 rounded-pill py-2"
              onClick={() => window.location.href = '/cadastrar'}
            >
              Cadastrar-se
            </Button>
          </Form>
        </Card.Body>
      </Card>
    </Container>
  )
}

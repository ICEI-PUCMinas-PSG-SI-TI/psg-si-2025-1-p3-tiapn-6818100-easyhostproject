import React, { useEffect, useState } from 'react'
import { jwtDecode } from 'jwt-decode'
import Header from './componente/Header'
import { Container } from 'react-bootstrap'

export default function Home() {
  const [userName, setUserName] = useState('')

  useEffect(() => {
    const token = localStorage.getItem('token')
    if (token) {
      try {
        const decoded = jwtDecode(token)
        setUserName(decoded.nome || '')
      } catch (err) {
        console.error('Erro ao decodificar token:', err)
      }
    }
  }, [])

  return (
    <>
      <Header />
      <Container className="mt-5">
        {userName ? (
          <h1>Olá, {userName}</h1>
        ) : (
          <h1>Bem-vindo(a) ao EasyHost</h1>
        )}
      </Container>
    </>
  )
}

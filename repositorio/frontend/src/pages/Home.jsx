import React, { useEffect, useState } from 'react';
import Header from '../pages/componente/Header.jsx';
import api from '../services/api';

export default function Home() {
  const [message, setMessage] = useState('');

  useEffect(() => {
    api.get('/hotel/run')
      .then(res => setMessage(res.data))
      .catch(() => setMessage('Erro ao conectar à API'));
  }, []);

  return (
    <>
      <Header/>
      <div className="container mt-5">
        <h1>Olá EasyHost</h1>
        {message && <p>API respondeu: {message}</p>}
      </div>
    </>
  );
}

import React, { useState, useEffect } from 'react';
import { Navbar, Container, Image } from 'react-bootstrap';
import api from '../../services/api';
import logo from '../../images/logo.png';

export default function Header() {
  const [hotelName, setHotelName] = useState('EasyHost');

  useEffect(() => {
    api.get('/hotel/GetAll')
      .then(res => setHotelName(res.data[0].nomeHotel))
      .catch(() => setHotelName('Erro ao carregar hotel'));
  }, []);

  return (
    <Navbar bg="secondary">

       <Navbar.Brand href="/" className='px-5'>
          <Image
            src={logo}
            alt="Logo"
            width={120}
            height={100}
            className="d-inline-block align-top me-2"
          />
        </Navbar.Brand>

      <Container>
        <Navbar.Text className="ms-auto text-white">
          {hotelName}
        </Navbar.Text>
      </Container>
    </Navbar>
  );
}

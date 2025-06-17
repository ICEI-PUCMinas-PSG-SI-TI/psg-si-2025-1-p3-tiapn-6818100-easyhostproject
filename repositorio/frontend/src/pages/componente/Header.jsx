import { Navbar, Nav, Container, Image } from "react-bootstrap";
import logo from "../../images/logo.png";
import { FaUser } from "react-icons/fa";
import React, { useEffect, useState } from "react";

export default function Header() {
  const [isLogged, setIsLogged] = useState(false);
  const [tipoUsuario, setTipoUsuario] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    setIsLogged(!!token);
  }, []);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      setIsLogged(true);
      try {
        const decoded = JSON.parse(atob(token.split(".")[1]));
        setTipoUsuario(decoded.tipoUsuario === "Administrador" ? 2 : 1);
      } catch (err) {
        console.error("Erro ao decodificar token:", err);
      }
    }
  }, []);

  return (
    <Navbar
      collapseOnSelect
      expand="lg"
      variant="dark"
      sticky="top"
      className="shadow"
      style={{
        backgroundColor: "rgba(222, 225, 233, 0.87)",
        padding: "0 5rem",
      }}
    >
      <Container fluid>
        <Navbar.Brand href="/" className="d-flex align-items-center">
          <Image
            src={logo}
            fluid
            style={{ maxHeight: "90px", width: "auto" }}
            className="me-2"
            alt="Logo"
          />
        </Navbar.Brand>
        <Navbar.Toggle
          aria-controls="responsive-navbar-nav"
          className="bg-dark"
        />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="d-flex flex-column flex-lg-row align-items-start align-items-lg-center">
            <Nav.Link className="text-dark" href="/">
              Home
            </Nav.Link>
            <Nav.Link className="text-dark" href="/quarto">
              Quartos
            </Nav.Link>
            <Nav.Link className="text-dark" href="/hospede">
              Hospedes
            </Nav.Link>
            <Nav.Link className="text-dark" href="/reserva/lista">
              Reservas
            </Nav.Link>
             <Nav.Link className="text-dark" href="/relatorios">
              Relatorio
            </Nav.Link>
          </Nav>
          <Nav className="d-flex flex-column flex-lg-row gap-2 ms-lg-auto mt-2 mt-lg-0">
            {tipoUsuario === 2 && (
              <Nav.Link className="text-dark" href="/cadastrar">
                Cadastrar
              </Nav.Link>
            )}
            <Nav.Link className="text-dark d-lg-none" href="/login">
              Login
            </Nav.Link>
            <Nav.Link
              className="text-white bg-primary rounded py-1 px-2 d-none d-lg-inline-flex align-items-center"
              href={isLogged ? "/usuario" : "/login"}
            >
              <FaUser size={20} className="me-1" />
              Login
            </Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

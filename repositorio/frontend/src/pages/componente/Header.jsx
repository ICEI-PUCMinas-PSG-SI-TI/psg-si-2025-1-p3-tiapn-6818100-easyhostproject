import { Navbar, Nav, Container, Image } from 'react-bootstrap';
import logo from '../../images/logo.png';
import { FaUser } from "react-icons/fa";

export default function Header() {
  return (
    <Navbar
      collapseOnSelect
      expand="lg"
      variant="dark"
      sticky="top"
      className="shadow-sm"
      style={{
        backgroundColor: 'rgba(0, 0, 0, 0.15)',
        height: '90px',
        padding: '0 1rem'
      }}
    >
      <Container>
        <Navbar.Brand href="/">
          <Image
            src={logo}
            height={130}
            className="d-inline-block align-top"
            alt="Logo"
          />
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="ms-auto ">
            <Nav.Link className='text-dark' href="/">Home</Nav.Link>
            <Nav.Link className='text-dark' href="/cadastrar">Cadastrar</Nav.Link>
            <Nav.Link className='text-dark' href="/login">  <FaUser size={20} /></Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

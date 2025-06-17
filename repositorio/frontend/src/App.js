import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Cadastrar from './pages/Cadastrar';
import Login from './pages/Login';
import Quarto from './pages/Quarto';
import Hospede from './pages/Hospede';
import CriarReserva from './pages/CriarReserva';
import ReservaLista from './pages/ReservaLista';
import VisualizarUsuario from './pages/VisualizarUsuario';
import Relatorios from './pages/Relatorios';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/cadastrar" element={<Cadastrar />} />
        <Route path="/login" element={<Login />} />
        <Route path="/quarto" element={<Quarto />} />
        <Route path="/hospede" element={<Hospede />} />
        <Route path="/reserva/lista" element={<ReservaLista />} />
        <Route path="/reserva/create" element={<CriarReserva />} />
        <Route path="/usuario" element={<VisualizarUsuario />} />
        <Route path="/relatorios" element={<Relatorios />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;

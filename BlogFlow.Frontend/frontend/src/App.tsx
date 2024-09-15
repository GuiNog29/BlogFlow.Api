import React from "react";
import { Routes, Route } from "react-router-dom";
import Home from "./pages/home/Home";
import Login from "./pages/login/Login";
import CadastrarUsuario from "./pages/usuario/CadastrarUsuario";
import EditarPostagem from "./pages/postagem/EditarPostagem";
import ListarUsuarios from "./pages/usuario/ListarUsuarios";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { GlobalStyle } from "./theme";

function App() {
  return (
    <div>
      <GlobalStyle />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/cadastrar-usuario" element={<CadastrarUsuario />} />
        <Route path="/editar-postagem/:id" element={<EditarPostagem />} />
        <Route path="/listar-usuarios" element={<ListarUsuarios />} />
      </Routes>
      <ToastContainer />s
    </div>
  );
}

export default App;

import React, { useState } from 'react';
import { Container, TextField, Button, Typography, Box } from '@mui/material';
import axios from 'axios';
import { toast } from 'react-toastify';

const CadastrarUsuario: React.FC = () => {
  const [nome, setNome] = useState('');
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  const handleCadastrar = () => {
    axios.post('http://localhost:5000/api/usuario/cadastrar', { nome, email, senha })
      .then(response => {
        toast.success("Usuário cadastrado com sucesso!");
      })
      .catch(error => {
        toast.error("Erro ao cadastrar usuário: " + error.response.data.message);
      });
  };

  return (
    <Container maxWidth="sm">
      <Typography variant="h4" gutterBottom>
        Cadastrar Usuário
      </Typography>
      <Box mb={2}>
        <TextField
          label="Nome"
          fullWidth
          variant="outlined"
          value={nome}
          onChange={e => setNome(e.target.value)}
          margin="normal"
        />
      </Box>
      <Box mb={2}>
        <TextField
          label="Email"
          fullWidth
          variant="outlined"
          value={email}
          onChange={e => setEmail(e.target.value)}
          margin="normal"
        />
      </Box>
      <Box mb={2}>
        <TextField
          label="Senha"
          fullWidth
          type="password"
          variant="outlined"
          value={senha}
          onChange={e => setSenha(e.target.value)}
          margin="normal"
        />
      </Box>
      <Button variant="contained" color="primary" fullWidth onClick={handleCadastrar}>
        Cadastrar
      </Button>
    </Container>
  );
};

export default CadastrarUsuario;

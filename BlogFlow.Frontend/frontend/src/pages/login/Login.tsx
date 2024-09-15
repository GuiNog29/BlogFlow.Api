import React, { useState } from 'react';
import { Container, TextField, Button, Typography, Box } from '@mui/material';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

const Login: React.FC = () => {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const navigate = useNavigate();

  const handleLogin = () => {
    axios.post('http://localhost:5000/api/usuario/login', { email, senha })
      .then(response => {
        toast.success("Login realizado com sucesso!");
        navigate('/');
      })
      .catch(error => {
        toast.error("Erro ao fazer login: " + error.response.data.message);
      });
  };

  return (
    <Container maxWidth="sm">
      <Typography variant="h4" gutterBottom>
        Login
      </Typography>
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
      <Button variant="contained" color="primary" fullWidth onClick={handleLogin}>
        Entrar
      </Button>
    </Container>
  );
};

export default Login;

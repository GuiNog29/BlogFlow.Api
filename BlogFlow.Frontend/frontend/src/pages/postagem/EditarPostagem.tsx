import React, { useState, useEffect } from 'react';
import { Container, TextField, Button, Typography, Box } from '@mui/material';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import { toast } from 'react-toastify';

const EditarPostagem: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const [titulo, setTitulo] = useState('');
  const [conteudo, setConteudo] = useState('');

  useEffect(() => {
    // Buscar a postagem existente pelo ID
    axios.get(`http://localhost:5000/api/postagem/visualizar/${id}`)
      .then(response => {
        const postagem = response.data;
        setTitulo(postagem.titulo);
        setConteudo(postagem.conteudo);
      })
      .catch(error => {
        toast.error("Erro ao carregar a postagem.");
      });
  }, [id]);

  const handleEditar = () => {
    // Atualizar a postagem no backend
    axios.put(`http://localhost:5000/api/postagem/editar`, { id, titulo, conteudo })
      .then(response => {
        toast.success("Postagem atualizada com sucesso!");
        navigate('/');
      })
      .catch(error => {
        toast.error("Erro ao atualizar a postagem.");
      });
  };

  return (
    <Container maxWidth="sm">
      <Typography variant="h4" gutterBottom>
        Editar Postagem
      </Typography>
      <Box mb={2}>
        <TextField
          label="Título"
          fullWidth
          variant="outlined"
          value={titulo}
          onChange={e => setTitulo(e.target.value)}
          margin="normal"
        />
      </Box>
      <Box mb={2}>
        <TextField
          label="Conteúdo"
          fullWidth
          multiline
          rows={4}
          variant="outlined"
          value={conteudo}
          onChange={e => setConteudo(e.target.value)}
          margin="normal"
        />
      </Box>
      <Button variant="contained" color="primary" fullWidth onClick={handleEditar}>
        Salvar Alterações
      </Button>
    </Container>
  );
};

export default EditarPostagem;

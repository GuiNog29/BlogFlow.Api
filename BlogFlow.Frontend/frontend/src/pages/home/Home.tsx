import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Container, Grid, Card, CardContent, Typography, CircularProgress } from '@mui/material';

interface Postagem {
  id: number;
  titulo: string;
  conteudo: string;
  dataCriacao: string;
}

const Home: React.FC = () => {
  const [postagens, setPostagens] = useState<Postagem[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios.get('https://localhost:32775/api/Postagem/Listar')
      .then(response => {
        setPostagens(response.data);
        setLoading(false);
      })
      .catch(error => {
        console.error("Erro ao carregar postagens:", error);
        setLoading(false);
      });
  }, []);

  return (
    <Container>
      <Typography variant="h4" gutterBottom>
        Postagens do Blog
      </Typography>
      {loading ? (
        <CircularProgress />
      ) : (
        <Grid container spacing={3}>
          {postagens.map(postagem => (
            <Grid item xs={12} sm={6} md={4} key={postagem.id}>
              <Card>
                <CardContent>
                  <Typography variant="h5">{postagem.titulo}</Typography>
                  <Typography variant="body2">{postagem.conteudo}</Typography>
                  <Typography variant="caption">
                    Data de criação: {new Date(postagem.dataCriacao).toLocaleDateString()}
                  </Typography>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      )}
    </Container>
  );
};

export default Home;

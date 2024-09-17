import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from '@/utils/axiosConfig';

interface Postagem {
  id: number;
  titulo: string;
  conteudo: string;
  dataCriacao: string;
}

export default function VisualizarPostagens() {
  const { postagemId } = useParams<{ postagemId: string }>();
  const [postagem, setPostagem] = useState<Postagem | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (postagemId) {
      api
        .get(`/api/Postagem/Visualizar/${postagemId}`)
        .then((response) => {
          setPostagem(response.data);
          setLoading(false);
        })
        .catch((error) => {
          console.error("Erro ao carregar a postagem:", error);
          setLoading(false);
        });
    }
  }, [postagemId]);

  return (
    <section>
      <div className="mx-auto max-w-6xl px-4 sm:px-6">
        <div className="pb-12 md:pb-20">
          <div className="mx-auto max-w-3xl pb-12 text-center md:pb-20">
            <div className="inline-flex items-center gap-3 pb-3">
              <span className="inline-flex bg-gradient-to-r from-indigo-500 to-indigo-200 bg-clip-text text-transparent">
                Detalhes da Postagem
              </span>
            </div>
          </div>

          {loading ? (
            <div className="text-center">
              <p>Carregando postagem...</p>
            </div>
          ) : (
            postagem && (
              <div className="mx-auto max-w-xl">
                <div className="bg-gray-800 p-6 rounded-lg shadow-lg">
                  <h2 className="text-2xl font-bold text-indigo-500">
                    {postagem.titulo}
                  </h2>
                  <p className="text-gray-300 mt-4">{postagem.conteudo}</p>
                  <p className="text-gray-500 mt-2 text-sm">
                    Data de criação:{" "}
                    {new Date(postagem.dataCriacao).toLocaleDateString()}
                  </p>
                </div>
              </div>
            )
          )}
        </div>
      </div>
    </section>
  );
}

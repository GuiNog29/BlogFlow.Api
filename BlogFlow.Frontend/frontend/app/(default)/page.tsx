export const metadata = {
  title: "BlogFlow",
};

import PageIllustration from "@/components/page-illustration";
import BlogFlowHome from "@/components/blogflow-home";
import ListarPostasgens from "@/components/postagens/listar";

export default function Home() {
  return (
    <>
      <PageIllustration />
      <BlogFlowHome />
      <ListarPostasgens />
    </>
  );
}

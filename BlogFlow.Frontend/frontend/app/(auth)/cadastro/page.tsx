export const metadata = {
  title: "Cadastro - BlogFlow",
};

import Link from "next/link";

export default function Cadastro() {
  return (
    <section>
      <div className="mx-auto max-w-6xl px-4 sm:px-6">
        <div className="py-12 md:py-20">
          <div className="pb-12 text-center">
            <h1 className="animate-[gradient_6s_linear_infinite] bg-[linear-gradient(to_right,theme(colors.gray.200),theme(colors.indigo.200),theme(colors.gray.50),theme(colors.indigo.300),theme(colors.gray.200))] bg-[length:200%_auto] bg-clip-text font-nacelle text-3xl font-semibold text-transparent md:text-4xl">
              Criar conta
            </h1>
          </div>
          <form className="mx-auto max-w-[400px]">
            <div className="space-y-5">
              <div>
                <label
                  className="mb-1 block text-sm font-medium text-indigo-200/65"
                  htmlFor="nome"
                >
                  Name <span className="text-red-500">*</span>
                </label>
                <input
                  id="nome"
                  type="text"
                  className="form-input w-full"
                  placeholder="Seu nome completo"
                  required
                />
              </div>
              <div>
                <label
                  className="mb-1 block text-sm font-medium text-indigo-200/65"
                  htmlFor="email"
                >
                  Email <span className="text-red-500">*</span>
                </label>
                <input
                  id="email"
                  type="email"
                  className="form-input w-full"
                  placeholder="Seu e-mail"
                />
              </div>
              <div>
                <label
                  className="block text-sm font-medium text-indigo-200/65"
                  htmlFor="senha"
                >
                  Senha <span className="text-red-500">*</span>
                </label>
                <input
                  id="senha"
                  type="password"
                  className="form-input w-full"
                  placeholder="Senha (pelo menos 10 caracteres)"
                />
              </div>
            </div>
            <div className="mt-6 space-y-5">
              <button className="btn w-full bg-gradient-to-t from-indigo-600 to-indigo-500 bg-[length:100%_100%] bg-[bottom] text-white shadow-[inset_0px_1px_0px_0px_theme(colors.white/.16)] hover:bg-[length:100%_150%]">
                Cadastrar
              </button>
            </div>
          </form>
          <div className="mt-6 text-center text-sm text-indigo-200/65">
            Já tem uma conta?{" "}
            <Link className="font-medium text-indigo-500" href="/login">
              Login
            </Link>
          </div>
        </div>
      </div>
    </section>
  );
}

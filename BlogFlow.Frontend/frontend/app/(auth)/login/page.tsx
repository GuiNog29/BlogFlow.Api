export const metadata = {
  title: "Login - BlogFlow",
};

import Link from "next/link";

export default function Login() {
  return (
    <section>
      <div className="mx-auto max-w-6xl px-4 sm:px-6">
        <div className="py-12 md:py-20">
          <div className="pb-12 text-center">
            <h1 className="animate-[gradient_6s_linear_infinite] bg-[linear-gradient(to_right,theme(colors.gray.200),theme(colors.indigo.200),theme(colors.gray.50),theme(colors.indigo.300),theme(colors.gray.200))] bg-[length:200%_auto] bg-clip-text font-nacelle text-3xl font-semibold text-transparent md:text-4xl">
              Bem-Vindo de volta
            </h1>
          </div>
          <form className="mx-auto max-w-[400px]">
            <div className="space-y-5">
              <div>
                <label
                  className="mb-1 block text-sm font-medium text-indigo-200/65"
                  htmlFor="email"
                >
                  Email
                </label>
                <input
                  id="email"
                  type="email"
                  className="form-input w-full"
                  placeholder="Seu email"
                />
              </div>
              <div>
                <div className="mb-1 flex items-center justify-between gap-3">
                  <label
                    className="block text-sm font-medium text-indigo-200/65"
                    htmlFor="senha"
                  >
                    Senha
                  </label>
                </div>
                <input
                  id="senha"
                  type="password"
                  className="form-input w-full"
                  placeholder="Sua senha"
                />
              </div>
            </div>
            <div className="mt-6 space-y-5">
              <button className="btn w-full bg-gradient-to-t from-indigo-600 to-indigo-500 bg-[length:100%_100%] bg-[bottom] text-white shadow-[inset_0px_1px_0px_0px_theme(colors.white/.16)] hover:bg-[length:100%_150%]">
                Login
              </button>
            </div>
          </form>
          {/* Bottom link */}
          <div className="mt-6 text-center text-sm text-indigo-200/65">
            Você não tem uma conta?{" "}
            <Link className="font-medium text-indigo-500" href="/cadastro">
              Cadastrar
            </Link>
          </div>
        </div>
      </div>
    </section>
  );
}

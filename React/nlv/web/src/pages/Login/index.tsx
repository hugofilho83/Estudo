import React, { useState } from "react";

import logoImg from "../../assets/images/logo_proffy.svg";
import backgroundLogoLogin from "../../assets/images/background_logo_login.svg";
import purpleHeartIcon from "../../assets/images/icons/purple-heart.svg";
import { AiOutlineEye } from "react-icons/ai";
import { AiOutlineEyeInvisible } from "react-icons/ai";

import "./styles.css";
import CheckBoxCustom from "../../components/CheckBoxCustom";

function Login() {
  const [isVisibilityPassword, setIsVisibilityPassword] = useState(false);

  function showPassword() {
    setIsVisibilityPassword(!isVisibilityPassword);
  }

  return (
    <div id="page-logo">
      <div id="page-logo-content" className="container">
        <div className="backgroudLogo">
          <div
            className="backgroudLogo-container"
            style={{
              backgroundImage: "url(" + backgroundLogoLogin + ")",
              backgroundPosition: "center",
              backgroundSize: "contain",
              backgroundRepeat: "no-repeat",
              margin: 10,
            }}
          >
            <div className="logo-container-login">
              <img src={logoImg} alt="logo Proffy" />
              <h2>Sua plataforma de estudos online.</h2>
            </div>
          </div>
        </div>

        <div className="fazer-login">
          <div className="area-login">
            <h1>Fazer Login</h1>

            <div className="div-email">
              <input type="text" id="email" placeholder="E-mail" />
            </div>

            <div className="div-password">
              <input
                type={isVisibilityPassword ? "text" : "password"}
                id="senha"
                placeholder="Senha"
              />
              <i
                onClick={showPassword}
                style={
                  isVisibilityPassword
                    ? { color: "#8257E5" }
                    : { color: "#9C98A6" }
                }
              >
                {isVisibilityPassword ? (
                  <AiOutlineEyeInvisible />
                ) : (
                  <AiOutlineEye />
                )}
              </i>
            </div>

            <div className="area-esqueci-lembrar">
              <div className="Lembre-me">
                {/* <input type="checkbox" name="lembrar" />
                <label htmlFor="lembrar">lembrar-me</label> */}
                <CheckBoxCustom isChecked label={"Lembre-me"} />
              </div>
              <div className="esqueci-senha">
                <a href="/" className="link-esqueci-senha">
                  Esqueci minha senha
                </a>
              </div>
            </div>

            <button type="submit" className="button-entrar">
              Entrar
            </button>

            <div className="footer-login">
              <div className="footer-login-cadastre-se">
                <span>Não tem conta?</span>
                <a href="Register">Cadastre-se</a>
              </div>
              <span className="de-graca">
                É de graça
                <img src={purpleHeartIcon} alt="coração roxo" />
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Login;

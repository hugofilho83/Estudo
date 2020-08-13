import React, { useState } from "react";
import { Link } from "react-router-dom";

import logoImg from "../../assets/images/logo_proffy.svg";
import backgroundLogoLogin from "../../assets/images/background_logo_login.svg";
import { AiOutlineEye } from "react-icons/ai";
import { AiOutlineEyeInvisible } from "react-icons/ai";
import backIcon from "../../assets/images/icons/back.svg";

import "./styles.css";

function Register() {
  const [isVisibilityPassword, setIsVisibilityPassword] = useState(false);

  function showPassword() {
    setIsVisibilityPassword(!isVisibilityPassword);
  }

  return (
    <div id="page-register">
      <div id="page-register-content" className="container">
        <div className="data-register">
          <header>
            <Link to="/">
              <img src={backIcon} alt="voltar" />
            </Link>
          </header>
          <div className="area-register-content">
            <div className="area-register">
              <h1>Cadastro</h1>
              <p>Preenche os dados abaixo para começar</p>

              <div className="registrer-nome">
                <input type="text" id="nome" placeholder="Nome" />
              </div>
              <div className="registrer-sobrenome">
                <input type="text" id="sobrenome" placeholder="Sobrenome" />
              </div>
              <div className="registrer-email">
                <input type="text" id="email" placeholder="E-mail" />
              </div>
              <div className="registrer-password">
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

              <button type="submit" className="button-entrar">
                Concluir Cadastro
              </button>
            </div>
          </div>
        </div>

        <div className="backgroudLogoRegister">
          <div
            className="backgroudLogoRegister-container"
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
      </div>
    </div>
  );
}

export default Register;

import React from "react";
import { Link } from "react-router-dom";

import logoImg from "../../assets/images/logo_proffy.svg";
import backgroundLogoLogin from "../../assets/images/background_logo_login.svg";
import backIcon from "../../assets/images/icons/back.svg";
import InputLabelCustom from "../../components/InputLabelFloat";

import "./styles.css";

function ResetPassword() {
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
              <h1>Eita, esqueceu sua senha?</h1>
              <p>Não esquenta, vamos dar um geito nisso.</p>

              <div className="registrer-email">
                <InputLabelCustom label="E-Mail" name="email" placeHolder=" " />
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

export default ResetPassword;

import React from "react";
import { Link } from "react-router-dom";

import logoImg from "../../assets/images/logo-proffy-purple.svg";
import backIcon from "../../assets/images/icons/back.svg";
import rocketIcon from "../../assets/images/icons/rocket.svg";
import "./styles.css";

interface PageHeaderProps {
  title?: string;
  titlePage: String;
  description?: string;
}

const PageHeader: React.FC<PageHeaderProps> = (props) => {
  return (
    <header className="page-header">
      <div className="top-bar-container">
        <Link to="/">
          <img src={backIcon} alt="Voltar" />
        </Link>
        <span id="title-header">{props.titlePage}</span>
        <img src={logoImg} alt="Logo Proffy" />
      </div>

      <div className="header-content">
        <strong>{props.title}</strong>
        <div className="subtitle">
          {props.description && <p>{props.description}</p>}
          <div className="rocket">
            <img src={rocketIcon} alt="foguete" />
            <span>Preparesse vai ser o maxímo.</span>
          </div>
        </div>

        {props.children}
      </div>
    </header>
  );
};

export default PageHeader;

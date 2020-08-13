import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import "./styles.css";

import logoImg from "../../assets/images/logo.svg";
import loadingImg from "../../assets/images/landing.svg";

import studyIcon from "../../assets/images/icons/study.svg";
import giveClassesIcon from "../../assets/images/icons/give-classes.svg";
import api from "../../services/api";

import { AiFillHeart } from "react-icons/ai";
import { AiOutlinePoweroff } from "react-icons/ai";

function Landing() {
  const [tatalConnections, setTotalConnections] = useState(0);

  useEffect(() => {
    api.get("/connections").then((response) => {
      const { total } = response.data;
      setTotalConnections(total);
    });
  }, []);

  return (
    <div id="page-landing">
      <div id="page-landing-content" className="container">
        <header>
          <a href="/" className="avatar">
            <img
              src="https://lh3.googleusercontent.com/a-/AOh14Gh1kKs_TfiXZ-qKrOzxM0H8kFScHX0au9J7xVvz2_4=s88-c-k-c0x00ffffff-no-rj-mo"
              alt="Avatar"
            />
            <span>Hugo Tavares</span>
          </a>

          <Link to="/" className="exit">
            <i>
              <AiOutlinePoweroff />
            </i>
          </Link>
        </header>
        <main>
          <div className="logo-container">
            <img src={logoImg} alt="logo Proffy" />
            <h2>Sua plataforma de estudos online.</h2>
          </div>

          <div>
            <img
              src={loadingImg}
              alt="Plataforma de estudos"
              className="hero-image"
            />
          </div>
        </main>
        <footer>
          <div className="footer-container">
            <div className="messeger-wellcome">
              <span>Seja bem-vindo.</span>
              <strong>O que deseja fazer?</strong>
            </div>
            <div className="buttons-container">
              <Link to="/study" className="study">
                <img src={studyIcon} alt="Estudar" />
                <span>Estudar</span>
              </Link>

              <Link to="/give-classes" className="give-classes">
                <img src={giveClassesIcon} alt="Dar Aulas" />
                Dar Aulas
              </Link>
            </div>
            <div className="total-connections">
              <span>
                Total de {tatalConnections} conexões já realizadas{" "}
                <i>
                  <AiFillHeart />
                </i>
              </span>
            </div>
          </div>
        </footer>
      </div>
    </div>
  );
}

export default Landing;

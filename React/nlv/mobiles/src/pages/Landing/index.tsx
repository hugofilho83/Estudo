import React, { useEffect, useState } from "react";
import { Image, Text, View } from "react-native";
import { useNavigation } from "@react-navigation/native";
import { RectButton } from "react-native-gesture-handler";

import api from "../../services/api";
import styles from "./style";

import landingImg from "../../assets/images/landing.png";
import studyIcon from "../../assets/images/icons/study.png";
import giveCalssesIcon from "../../assets/images/icons/give-classes.png";
import heartIcon from "../../assets/images/icons/heart.png";

function Landing() {
  const navigatior = useNavigation();
  const [connections, setTotalConnectioms] = useState(0);

  /*useEffect -> usado para executar uma function assim que aplicação é executada
  /*se no array que é passado como parametro for informada uma variavel toda vez que 
  /*ele for atualizada a function é executada novamente.
  */
  useEffect(() => {
    api.get("/connections").then((response) => {
      const { total } = response.data;
      setTotalConnectioms(total);
    });
  }, []);

  function handleNavigationToGiveClassesPage() {
    navigatior.navigate("GiveClasses");
  }

  function handleNavigationToStudyPage() {
    navigatior.navigate("Study");
  }

  return (
    <View style={styles.container}>
      <Image source={landingImg} style={styles.banner} />

      <Text style={styles.title}>
        Seja bem-vindos, {"\n"}
        <Text style={styles.titleBold}>0 que deseja fazer?</Text>
      </Text>

      <View style={styles.buttonsContainer}>
        <RectButton
          onPress={handleNavigationToStudyPage}
          style={[styles.button, styles.buttonPrimary]}
        >
          <Image source={studyIcon} />

          <Text style={styles.buttonText}>Estudar</Text>
        </RectButton>

        <RectButton
          onPress={handleNavigationToGiveClassesPage}
          style={[styles.button, styles.buttonSecondary]}
        >
          <Image source={giveCalssesIcon} />

          <Text style={styles.buttonText}>Dar Aula</Text>
        </RectButton>
      </View>
      <Text style={styles.totalConnections}>
        Total de {connections} conexões já ralizadas{"  "}
        <Image source={heartIcon} />
      </Text>
    </View>
  );
}

export default Landing;

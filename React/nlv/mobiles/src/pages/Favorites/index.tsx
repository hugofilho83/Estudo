import React, { useState } from "react";
import { ScrollView, View } from "react-native";
import PageHeader from "../../componets/PageHeader";
import TeacherItem, { Teacher } from "../../componets/TeacherItem";
import AsyncStorege from "@react-native-community/async-storage";
import { useFocusEffect } from "@react-navigation/native";

import styles from "./styles";

function Favorites() {
  /*guarda o estado da lista de professores favoritados */
  const [favorites, setFavorites] = useState([]);

  function loadFavorites() {
    AsyncStorege.getItem("favorites").then((response) => {
      if (response) {
        const favoritedTeachers = JSON.parse(response);

        setFavorites(favoritedTeachers);
      }
    });
  }

  useFocusEffect(() => {
    loadFavorites();
  });

  return (
    <View style={styles.container}>
      <PageHeader title="Meus Proffys favoritos" />
      <ScrollView
        style={styles.teacherList}
        contentContainerStyle={{
          paddingHorizontal: 16,
          paddingBottom: 16,
        }}
      >
        {favorites.map((teacherFavorited: Teacher) => {
          return (
            <TeacherItem
              key={teacherFavorited.id}
              teacher={teacherFavorited}
              favorited={true}
            />
          );
        })}
      </ScrollView>
    </View>
  );
}

export default Favorites;

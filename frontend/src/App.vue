<template>
  <div class="app">
    <h1>Test de Communication</h1>
    <div class="status-panel">
      <div class="status-card">
        <h3>Base de données ➡️ Backend ➡️ Frontend</h3>
        <p>Message de la base de données : {{ databaseMessage }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import { api } from "./services/api";

export default {
  name: "App",
  data() {
    return {
      databaseMessage: "Chargement du message depuis la base de données...",
    };
  },
  async mounted() {
    try {
      const response = await api.get("/api/message");
      this.databaseMessage = response.data.message;
    } catch (error) {
      this.databaseMessage = "❌ Erreur de connexion avec le backend";
      console.error("Erreur détaillée:", error.response?.data || error.message);
    }
  },
};
</script>

<style>
.app {
  text-align: center;
  padding: 20px;
}

.status-panel {
  margin-top: 20px;
}

.status-card {
  padding: 20px;
  border: 1px solid #ddd;
  border-radius: 8px;
  margin: 10px;
}
</style>

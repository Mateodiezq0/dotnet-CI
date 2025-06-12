<script lang="ts">
  import { onMount } from "svelte";

  let resultado: number = 0;

  // Realizamos la llamada a la API para obtener el resultado de la suma
  onMount(async () => {
    const response = await fetch("http://localhost:5000/sumar?a=5&b=3");
    if (response.ok) {
      const data = await response.json();
      resultado = data; // Guardamos el resultado en la variable
    } else {
      console.error("Error al obtener el resultado de la suma");
    }
  });
</script>

<main>
  <h1>Resultado de la suma: {resultado}</h1>
</main>

<script lang="ts">
  import { onMount } from "svelte";
  import ReporteCobertura from './ReporteCobertura.svelte';  // Asegúrate de que la ruta sea correcta

  let palabra: string = "";  // La palabra que el usuario ingresa
  let mensaje: string = "";  // Mensaje de respuesta del servidor

  // Leer la URL del backend desde la variable de entorno
  const backendUrl = import.meta.env.VITE_BACKEND_URL;

  // Realizamos la llamada a la API para comprobar la palabra al hacer clic
  const comprobarPalabra = async () => {
    //const response = await fetch(`${backendUrl}/comprobar?palabra=${palabra}`);

    const response = await fetch(`${backendUrl}/comprobar?palabra=${palabra}`);
      
    if (response.ok) {
      mensaje = await response.text(); // Si la respuesta es exitosa, asignamos el mensaje
    } else {
      mensaje = "La palabra es incorrecta."; // Si hay error, asignamos un mensaje de error
    }
  };
</script>

<main>
  <h1>Comprobador de Palabra</h1>
  <div>
    <input bind:value={palabra} placeholder="Introduce una palabra " />
    <button on:click={comprobarPalabra}>Comprobar</button>
  </div>
  <p>{mensaje}</p>

  <ReporteCobertura />
</main>

<style>
  input {
    font-size: 1.5rem;
    padding: 0.5rem;
    margin: 0.5rem;
  }

  button {
    padding: 0.5rem;
    font-size: 1.2rem;
  }

  .verde {
    color: green;
  }

  .amarillo {
    color: yellow;
  }

  .gris {
    color: gray;
  }
</style>

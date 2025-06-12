<script lang="ts">
  import { Router, Route, Link } from 'svelte-routing';
  import { onMount } from "svelte";

  let mensaje: string = "";  // Mensaje de respuesta del servidor
  let xmlUrl = `https://dotnet-ci-app.onrender.com/coverage/coverage.cobertura.xml`;  // URL del XML en el backend
  let xmlContent: string = '';  // Para almacenar el contenido del XML

  // Realizamos la llamada a la API para obtener el contenido del XML cuando estamos en /coverage
  const obtenerXML = async () => {
    const response = await fetch(xmlUrl);
    if (response.ok) {
      xmlContent = await response.text();  // Guardamos el contenido del XML
    } else {
      xmlContent = "Error al cargar el archivo XML.";
    }
  };
</script>

<main>
  <!-- Definir rutas -->
  <Router>
    <!-- Enlaces de navegación -->
    <nav>
      <Link to="/">Inicio</Link>
      <Link to="/coverage">Cobertura</Link>
    </nav>

    <!-- Rutas -->
    <Route path="/" let:params>
      <h1>Bienvenido al Comprobador de Palabra</h1>
      <div>
        <input bind:value={mensaje} placeholder="Introduce una palabra" />
        <button on:click={async () => {
          const response = await fetch(`${import.meta.env.VITE_BACKEND_URL}/comprobar?palabra=${mensaje}`);
          if (response.ok) {
            mensaje = await response.text();
          } else {
            mensaje = "La palabra es incorrecta.";
          }
        }}>Comprobar</button>
      </div>
    </Route>

    <Route path="/coverage" let:params>
      <h1>Reporte de Cobertura</h1>
      <!-- Cargar y mostrar XML solo si estamos en /coverage -->
      <div>
        {#if xmlContent}
          <pre>{xmlContent}</pre> <!-- Mostrar XML en un formato preformateado -->
        {:else}
          <p>Cargando XML...</p>
          <button on:click={obtenerXML}>Cargar Reporte de Cobertura</button>
        {/if}
      </div>
    </Route>
  </Router>
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

  nav {
    margin: 20px 0;
  }

  nav a {
    margin: 0 10px;
    text-decoration: none;
    color: #000;
  }
</style>

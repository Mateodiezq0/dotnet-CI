<script lang="ts">
  let xmlUrl: string = "/coverage/coverage.cobertura.xml";  // Ruta del archivo XML
</script>

<main>
  <h1>Reporte de Cobertura</h1>
  <!-- iframe para mostrar el XML -->
  <iframe src={xmlUrl} width="100%" height="600px" frameborder="0"></iframe>
</main>

<style>
  iframe {
    border: 1px solid #ccc;
    border-radius: 5px;
  }
</style>

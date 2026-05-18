/**
 * @description Genera datos de prueba para los campos de fecha y consumo electrico.
 * Llena los campos con fechas del año actual y consumos aleatorios entre 150 y 450 kWh.
 */
function generateTestData() {
  const currentYear = new Date().getFullYear() - 1;

  for (let i = 0; i < 12; i++) {
    const dateInput = document.querySelector(
      `input[name="History[${i}].Date"]`,
    );
    const consumptionInput = document.querySelector(
      `input[name="History[${i}].ConsumptionKwh"]`,
    );

    if (dateInput && consumptionInput) {
      // Generamos una fecha para el dia 15 de cada mes del año actual
      // El mes con el padding de "0" asi quedaria algo como: 2024-01-15, 2024-02-15, etc.
      const month = (i + 1).toString().padStart(2, "0");
      dateInput.value = `${currentYear}-${month}-15`;

      // Generamos un consumo aleatorio entre 150 y 450 kWh, con dos decimales
      const randomConsumption = (Math.random() * (450 - 150) + 150).toFixed(2);
      consumptionInput.value = randomConsumption;
    }
  }
}

// Exponemos la func al objeto global para que el atrib 'onclick' del HTML lo encuentre
globalThis.generateTestData = generateTestData;

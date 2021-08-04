const form = document.getElementById('form');
form.addEventListener('submit', handleSubmit);

function handleSubmit(event) {
  event.preventDefault();

  const gender = getSelectValue('gender')
  const age = getInputNumberValue('age');
  const weight = getInputNumberValue('weight');
  const height = getInputNumberValue('height');
  const activityLevel = getSelectValue('activity_level');

  const tmb = Math.round(
    gender === 'female'
    ? (655 + (9.6 * weight) + (1.8 * height) - (4.7 * age))
    : (66 + (13.7 * weight) + (5 * height) - (6.8 * age))
  );

  const mainterance = Math.round(tmb * Number(activityLevel));
  const loseWeight = mainterance - 450;
  const gainWeight = mainterance + 450;

  const layout = `
  <h2>Aqui está o resultado:</h2>

  <div class="result-content">
    <ul>
      <li>
        Seu metabolismo basal é de <strong>${tmb} calorias</strong>.
      </li>
      <li>
        Para manter o seu peso você precisa consumir em média <strong>${mainterance} calorias</strong>.
      </li>
      <li>
        Para perder peso você precisa consumir em média <strong>${loseWeight} calorias</strong>.
      </li>
      <li>
        Para ganhar peso você precisa consumir em média <strong>${gainWeight} calorias</strong>.
      </li>
    </ul>
  </div>
  `;

  const result = document.getElementById("result");
  result.innerHTML = layout;
}

function getInputNumberValue(id) {
  return Number(document.getElementById(id).value);
}

function getSelectValue(id) {
  const select = document.getElementById(id);
  return select.options[select.selectedIndex].value;
}
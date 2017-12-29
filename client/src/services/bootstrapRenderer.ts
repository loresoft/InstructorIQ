import { ValidationRenderer, RenderInstruction, ValidateResult } from 'aurelia-validation';

export class BootstrapRenderer {
  render(instruction: RenderInstruction) {
    for (let { result, elements } of instruction.unrender) {
      for (let element of elements) {
        this.remove(element, result);
      }
    }

    for (let { result, elements } of instruction.render) {
      for (let element of elements) {
        this.add(element, result);
      }
    }
  }

  add(element: Element, result: ValidateResult) {
    if (result.valid) {
      return;
    }

    const formGroup = element.closest('.form-group');
    if (!formGroup) {
      return;
    }

    const message = document.createElement('div');
    message.className = 'invalid-feedback';
    message.textContent = result.message;
    message.id = `validation-message-${result.id}`;

    element.classList.add('is-invalid');

    formGroup.appendChild(message);
  }

  remove(element: Element, result: ValidateResult) {
    if (result.valid) {
      return;
    }

    const formGroup = element.closest('.form-group');
    if (!formGroup) {
      return;
    }

    const message = formGroup.querySelector(`#validation-message-${result.id}`);
    if (message) {
      formGroup.removeChild(message);

      if (formGroup.querySelectorAll('.invalid-feedback').length === 0) {        
        element.classList.remove('is-invalid');
      }
    }
  }
}

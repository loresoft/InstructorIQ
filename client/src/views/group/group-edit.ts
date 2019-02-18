import { autoinject, bindable } from 'aurelia-framework';
import { AppRouter } from "aurelia-router";
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";
import { Notifier } from "services/notifier";
import { BootstrapRenderer } from 'services/bootstrapRenderer';
import { GroupRepository } from 'repositories/groupRepository';
import { GroupRead } from 'models/groupRead';
import { compare } from 'fast-json-patch';


@autoinject
export class GroupEdit {
  @bindable loading: boolean;
  @bindable dirty: boolean = false;

  @bindable name: string;
  @bindable description: string;
  @bindable sequence: number;

  original: GroupRead;

  controller: ValidationController;

  constructor(
    private router: AppRouter,
    private notifier: Notifier,
    private controllerFactory: ValidationControllerFactory,
    private groupRepository: GroupRepository
  ) {
    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapRenderer());

    this.configureValidation();
  }

  configureValidation() {
    ValidationRules
      .ensure((m: GroupEdit) => m.name)
      .displayName("Name")
      .required()
      .maxLength(256)
      .ensure((m: GroupEdit) => m.sequence)
      .displayName("Sequence")
      .required()      
      .on(this);
  }

  async activate(params, routeConfig, navigationInstruction) {
    this.notifier.clear();

    if (params.id) {
      await this.load(params.id);
    }
  }

  async processForm() {
    let v = await this.controller.validate();
    if (!v.valid) {
      this.notifier.error("Please ensure all fields are filled out.");
      return;
    }

    this.loading = true;
    try {
      if (this.original) {
        await this.update();
      } else {
        await this.create();
      }
    } catch (e) {
      await this.notifier.error(e);
    } finally {
      this.loading = false;
    }
  }

  async create() {
    const request = {
      name: this.name,
      description: this.description,
      sequence: this.sequence
    }

    const group = await this.groupRepository.create(request);

    // redirect to edit page
    this.router.navigateToRoute('groupEdit', { id: group.id })
  }

  async update() {
    const original = {
      name: this.original.name,
      description: this.original.description,
      sequence: this.original.sequence
    }
    const current = {
      name: this.name,
      description: this.description,
      sequence: this.sequence
    }

    const operations = compare(original, current);
    const group = await this.groupRepository.patch(this.original.id, operations);

    this.notifier.success("Group saved successfully")

    // don't replace original reference, copy updates
    Object.assign(this.original, group);

    this.resetForm();
  }

  async load(id: string) {
    this.loading = true;
    try {
      this.original = await this.groupRepository.read(id);

      this.name = this.original.name;
      this.description = this.original.description;
      this.sequence = this.original.sequence;

    } catch (e) {
      await this.notifier.error(e);
    } finally {
      this.loading = false;
    }
  }

  async delete(){
    console.log("delete");
  }

  resetForm() {
    this.dirty = false;
    if (this.original) {
      this.name = this.original.name;
      this.description = this.original.description;
      this.sequence = this.original.sequence;
    } else {
      this.name = '';
      this.description = '';
      this.sequence = 0;
    }
  }
}

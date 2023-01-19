import { Component } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from 'src/app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {

  constructor(private fb : FormBuilder){}
  ngOnInit():void{
    this.validation();
  }

  form!:FormGroup;

  get f():any{
    return this.form.controls;
  }

  public validation():void{

    const formOptions: AbstractControlOptions = {
      validators : ValidatorField.MustMatch('senha', 'confirmarSenha')
    }

    this.form = this.fb.group({
      primeiroNome:['',[Validators.required]],
      ultimoNome:['',[Validators.required]],
      email:['',[Validators.required,Validators.email]],
      usuario:['',[Validators.required]],
      senha:['',[Validators.required,Validators.minLength(6)]],
      confirmarSenha:['',[Validators.required]]
    }, formOptions);
  }
}

import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from 'src/app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  constructor( private fb : FormBuilder) { }

  ngOnInit() {
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
      titulo:['',[Validators.required]] ,
      primeiroNome:['',[Validators.required]] ,
      ultimoNome:['',[Validators.required]] ,
      email:['',[Validators.required,Validators.email]] ,
      telefone:['',[Validators.required]] ,
      funcao:['',[Validators.required]] ,
      descricao:['',[Validators.required,Validators.minLength(30)]] ,
      senha:['',[Validators.minLength(6)]] ,
      confirmarSenha:['',[]] ,
    }, formOptions);
  }

  public resetForm(): void{
    this.form.reset();
  }

}

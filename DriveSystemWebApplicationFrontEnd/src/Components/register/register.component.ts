import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Validators,FormGroup,FormControl } from '@angular/forms';
import { RegisterService } from 'src/services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  rigisterForm =new FormGroup({
    name: new FormControl('',[Validators.required]),
    userName: new FormControl('',[Validators.required,Validators.minLength(3)]),
    email: new FormControl('',[Validators.required,Validators.pattern('[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}')]),
    password: new FormControl('',[Validators.required,Validators.minLength(8)]),
    selectedRole: new FormControl('', [Validators.required])

})




get getName(){
  return this.rigisterForm.controls['name']
};
get getUserName(){
  return this.rigisterForm.controls['userName']
};get getEmail(){
  return this.rigisterForm.controls['email']
};get getPassword(){
  return this.rigisterForm.controls['password']
};get getSelectedRole(){
  return this.rigisterForm.controls['selectedRole']
};

  constructor(private router: Router,
    private registerService:RegisterService) {}

  register() {
    const User={
      username:this.rigisterForm.value.userName,
      fullName:this.rigisterForm.value.name,
      email:this.rigisterForm.value.email,
      password:this.rigisterForm.value.password,
      role:this.rigisterForm.value.selectedRole,
      isDeleted:false
    }
    console.log(User);

    this.registerService.Register(User).subscribe((response)=>{
      next:
      console.log("added");
      this.rigisterForm.reset();

    });

    this.router.navigate(['/login']);
  }
}

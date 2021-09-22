import { Component } from '@angular/core';
import { UserInfoService } from 'src/services/user-info.service';
import { UserInfo } from 'src/models/user-info.models';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {
  cash: number = 0;
  userInfo: UserInfo = { fullName: '' };
  error: HttpErrorResponse = undefined;
  timer: NodeJS.Timeout = undefined;

  constructor(private userInfoService: UserInfoService) {
  }

  getUserCashInWords() {
    this.userInfoService.getUserCashInWords(this.cash, this.userInfo.fullName).subscribe(result => {
      result.fullName = result.fullName ? result.fullName : '';
      this.userInfo = result;
    }, (err: HttpErrorResponse) => {
      this.userInfo.cashInWords = undefined;
      this.error = err;
      if (this.timer)
        clearTimeout();
      else
        this.timer = setTimeout(() => { 
          this.error = undefined;
          this.timer = undefined;
         }, 2000);
    });
  }

}
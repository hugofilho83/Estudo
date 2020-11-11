import { NgModule } from '@angular/core';
import { FormatMoneyPipe } from './format-money.pipe';
import { ReplacePipe } from './replace.pipe';

@NgModule({
  declarations: [ReplacePipe, FormatMoneyPipe],
  exports: [ReplacePipe, FormatMoneyPipe],
})
export class AppPipeModule {}

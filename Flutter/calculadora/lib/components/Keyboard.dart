import 'package:calculadora/components/Keyboard.dart';
import 'package:flutter/material.dart';
import 'Button.dart';
import 'Button_row.dart';

class Keyboard extends StatelessWidget {
  final void Function(String) callBack;

  Keyboard(this.callBack);

  @override
  Widget build(BuildContext context) {
    return Expanded(
      flex: 2,
      child: Container(
        height: 500,
        child: Column(
          children: <Widget>[
            ButtonRow([
              Button.dark(text: 'AC', callBack: callBack),
              Button.dark(text: 'C', callBack: callBack),
              Button.dark(text: '%', callBack: callBack),
              Button.operantion(text: '/', callBack: callBack),
            ]),
            SizedBox(height: 1),
            ButtonRow([
              Button(text: '7', callBack: callBack),
              Button(text: '8', callBack: callBack),
              Button(text: '9', callBack: callBack),
              Button.operantion(text: 'X', callBack: callBack),
            ]),
            SizedBox(height: 1),
            ButtonRow([
              Button(text: '4', callBack: callBack),
              Button(text: '5', callBack: callBack),
              Button(text: '6', callBack: callBack),
              Button.operantion(text: '-', callBack: callBack),
            ]),
            SizedBox(height: 1),
            ButtonRow([
              Button(text: '1', callBack: callBack),
              Button(text: '2', callBack: callBack),
              Button(text: '3', callBack: callBack),
              Button.operantion(text: '+', callBack: callBack),
            ]),
            SizedBox(height: 1),
            ButtonRow([
              Button.big(text: '0', callBack: callBack),
              Button(text: '.', callBack: callBack),
              Button.operantion(text: '=', callBack: callBack),
            ]),
          ],
        ),
      ),
    );
  }
}

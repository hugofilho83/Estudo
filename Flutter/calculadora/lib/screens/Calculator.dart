import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import '../components/Display.dart';
import '../components/Keyboard.dart';
import '../models/Memory.dart';

class Calculator extends StatefulWidget {
  @override
  _CalculatorState createState() => _CalculatorState();
}

class _CalculatorState extends State<Calculator> {
  final Memory memory = Memory();
  _onPressed(String command) {
    setState(() {
      memory.applyCommand(command);
    });
  }

  @override
  Widget build(BuildContext context) {
    SystemChrome.setPreferredOrientations([
      DeviceOrientation.portraitUp,
    ]);
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Column(
        children: <Widget>[
          Display(memory.value),
          Keyboard(_onPressed),
        ],
      ),
    );
  }
}

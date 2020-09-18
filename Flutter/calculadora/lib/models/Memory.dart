class Memory {
  static const operations = const ['%', '/', 'X', '-', '+', '='];
  final _buffer = [0.0, 0.0];
  int _bufferIndex = 0;
  String _value = '0';
  String _operantion;
  bool _wipeValue = false;
  String _lastCommand = '';

  void applyCommand(String command) {
    if (_isRepalaceOperation(command)) {
      _operantion = command;
      return;
    }

    if (command == 'AC') {
      _allClear();
    } else if (command == 'C') {
      _clear();
    } else if (operations.contains(command)) {
      _setOperation(command);
    } else {
      _addDigito(command);
    }

    _lastCommand = command;
  }

  _isRepalaceOperation(String command) {
    return operations.contains(_lastCommand) &&
        operations.contains(command) &&
        _lastCommand != '=' &&
        command != '=';
  }

  _setOperation(String newOperation) {
    bool isEqualSign = newOperation == '=';
    if (newOperation == '%') {
      double valor = _calcularPercentual();
      _buffer[_bufferIndex] = valor;
      this.value = _buffer[_bufferIndex].toString();
      this.value = _value.endsWith('.0') ? _value.split('.')[0] : _value;
      return;
    }

    if (_bufferIndex == 0) {
      if (!isEqualSign) {
        _bufferIndex = 1;
        _wipeValue = true;
        _operantion = newOperation;
      }
    } else {
      _buffer[0] = _calculater();
      _buffer[1] = 0;
      _value = _buffer[0].toString();
      this.value = _value.endsWith('.0') ? _value.split('.')[0] : _value;

      _operantion = isEqualSign ? null : newOperation;
      _bufferIndex = isEqualSign ? 0 : 1;
    }
    _wipeValue = true; //isEqualSign;
  }

  _calculater() {
    switch (_operantion) {
      case '/':
        return _buffer[0] / _buffer[1];
      case 'X':
        return _buffer[0] * _buffer[1];
      case '-':
        return _buffer[0] - _buffer[1];
      case '+':
        return _buffer[0] + _buffer[1];
      default:
        return _buffer[0];
    }
  }

  _addDigito(String digito) {
    final isDot = digito == '.';
    final wipeValue = (_value == '0' && !isDot) || _wipeValue;

    if (isDot && _value.contains('.') && !wipeValue) {
      return;
    }

    final emptyValue = isDot ? '0' : '';
    final currentValue = wipeValue ? emptyValue : _value;
    value = currentValue + digito;
    _wipeValue = false;

    _buffer[_bufferIndex] = double.tryParse(_value.replaceAll(",", ".")) ?? 0;
  }

  _allClear() {
    _value = '0';
    _buffer.setAll(0, [0.0, 0.0]);
    _bufferIndex = 0;
    _operantion = null;
    _wipeValue = false;
  }

  _clear() {
    _value = '0';
    _buffer[_bufferIndex] = 0.0;
  }

  _calcularPercentual() {
    if (_buffer[0] != 0 && _buffer[1] != 00) {
      if (_operantion == 'X') {
        return _buffer[1] / 100;
      } else {
        return ((_buffer[0] * _buffer[1]) / 100);
      }
    } else {
      return 0.0;
    }
  }

  String get value {
    return _value;
  }

  set value(String value) {
    this._value = value.replaceAll(".", ",");
  }
}

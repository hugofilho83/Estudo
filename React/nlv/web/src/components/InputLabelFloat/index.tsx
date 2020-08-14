import React, { InputHTMLAttributes } from "react";
import "./styles.css";

interface InputLabelProps extends InputHTMLAttributes<HTMLInputElement> {
  name: string;
  label: string;
  placeHolder: string;
}

const InputLabelCustom: React.FC<InputLabelProps> = ({
  label,
  name,
  placeHolder,
  ...rest
}) => {
  return (
    <div className="label-float">
      <input type="text" id={name} {...rest} placeholder={placeHolder} />
      <label htmlFor={name}>{label}</label>
    </div>
  );
};

export default InputLabelCustom;

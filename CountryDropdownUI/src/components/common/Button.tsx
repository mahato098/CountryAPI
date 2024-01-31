import { FaPlus } from "react-icons/fa";

type ButtonProps = {
    handleClick: (event: React.MouseEvent<HTMLButtonElement>) => void,
    value: string
}

const Button = (props: ButtonProps) => {
  return (
    <div>
      <button onClick={props.handleClick} className="flex justify-center items-center">
        <FaPlus /> {props.value}
      </button>
    </div>
  )
}

export default Button

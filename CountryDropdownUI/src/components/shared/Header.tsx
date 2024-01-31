import { FaSearch } from "react-icons/fa"

const Header = () => {
  return (
    <div>
      <div className='p-2.5 flex items-center rounded-md px-4 duration-300 cursor-pointer bg-neutral-900 text-white w-[1090px]'>
        <i className='text-sm'>
          <FaSearch />
        </i>
        <input type='text' placeholder='Search' className='text-[15px] ml-4 w-full bg-transparent focus: outline-none' />
      </div>
    </div>
  )
}

export default Header

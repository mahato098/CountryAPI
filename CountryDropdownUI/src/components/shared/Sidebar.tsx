import { BsAppIndicator } from "react-icons/bs"
import { Dashboard_Sidebar_Link } from "../lib/const/Navigation"
import { Link, useLocation } from "react-router-dom"
import classnames from "classnames";
import React from "react";


const linkClasses = "flex items-center gap-2 font-light px-3 py-2 hover:bg-neutral-700 hover:no-underline active:bg-neutral-600 rounded-sm text-base";

interface SidebarLinkProp {
  item: {
    key: string,
    path: string,
    icon: React.ReactNode,
    label: string
  }
}

const Sidebar = () => {
  return (
    <div className="bg-neutral-900 w-60 p-3 flex flex-col text-white">
      <div>
        <div className='p-2.5 mt-1 flex items-center cursor-pointer'>
          <i className='px-2 py-2 w-[35px] h-[35px] flex items-center rounded-md bg-blue-600'>
            <BsAppIndicator />
          </i>
          <h1 className='font-bold text-gray-200 text-[15px] ml-3'>Amazing Coder</h1>
        </div>

        <div className='my-2 bg-gray-600 h-[1px]'></div>

        <div className="flex-1 py-8 flex flex-col gap-0.5">
          {Dashboard_Sidebar_Link.map((item) => (
            <SidebarLink key={item.key} item={item} />
            
          ))}
        </div>

      </div>
    </div>
  )
}

export default Sidebar

function SidebarLink({item}: SidebarLinkProp){

  const {pathname} = useLocation();

  return(
    <Link to={item.path} className={classnames(pathname === item.path ? 'bg-neutral-700 text-white' : 'text-neutral-400', linkClasses) }>
      <span className="text-xl">{item.icon}</span>
      {item.label}
    </Link>
  )
}


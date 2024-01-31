import { Outlet } from 'react-router-dom'
import Sidebar from './Sidebar'
import Header from './Header'

const Layout = () => {
  return (
    <div className='flex flex-row bg-neutral-100 h-screen w-screen overflow-hidden'>
        <Sidebar />
        
      <div className='p-4'>
        <div>
          <Header />
        </div>
        <div className='mt-5 flex flex-col'>
            {<Outlet />}
        </div>
      </div>
    </div>
  )
}

export default Layout

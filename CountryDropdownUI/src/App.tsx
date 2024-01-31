import {BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import './App.css'
import Layout from './components/shared/Layout'
import Dashboard from './pages/Dashboard'
import List from './pages/country/List'
import StateList from './pages/state/List'
import DistrictList from './pages/district/List'
import CityList from './pages/city/List'
import PersonList from './pages/person/List'
import {QueryClient, QueryClientProvider} from '@tanstack/react-query'

const queryClient = new QueryClient();

function App() {

  return (
    <QueryClientProvider client={queryClient}>
      <Router>
        <Routes>
          <Route path='/' element={<Layout />}>
            <Route index element={<Dashboard />} />
            <Route path='/country/list' element={<List />} />
            <Route path='/state/list' element={<StateList />} />
            <Route path='/district/list' element={<DistrictList />} />
            <Route path='/city/list' element={<CityList />} />
            <Route path='/person/list' element={<PersonList />} />
          </Route>
        </Routes>
      </Router>
    </QueryClientProvider>
  )
}

export default App

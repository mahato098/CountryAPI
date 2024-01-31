import { useQuery } from "@tanstack/react-query"
import BASE_URL from '../../constant/BASE_URL'
import axios from 'axios'


interface IState {
    stateId: number,
    stateName: string
}


const List = () => {

    const fetchState = async() => {
        try{
            const response = await axios.get<IState[]>(`${BASE_URL}/State/GetAllStates`);
            return response.data;
        }
        catch(error){
            throw new Error(`Error Fetching State List: ${error}`)
        }
    }

    const {data, error, isLoading, isError} = useQuery<IState[], Error>({
        queryKey: ["states"],
        queryFn: fetchState
    })

    if(isError) return <div>Error Occurred: ${error.message}</div>

    if(isLoading) return <div>Loading...</div>

    console.log("states :", data)

  return (
    <div className="mt-[30px]">
        <table className="min-w-full text-left text-sm font-light ml-6 mt-5">
        <thead className="border-b font-medium dark:border-neutral-500">
            <tr>
            <th>No.</th>
            <th>State Name</th>
            </tr>
        </thead>

        <tbody>
            {
            data?.map((state, index) => (
                <tr key={state.stateId} className="text-gray-900">
                <td>{index + 1}</td>
                <td>{state.stateName}</td>
                </tr>
            ))
            }
        </tbody>

        </table>
   </div>
  )
}

export default List

import { useQuery } from '@tanstack/react-query'
import BASE_URL from '../../constant/BASE_URL'
import axios from 'axios'


interface ICity {
    cityId: number,
    cityName: string
}

const List = () => {
    const fetchCity = async() => {
        try{
            const response = await axios.get<ICity[]>(`${BASE_URL}/City/GetAllCities`);
            return response.data;
        }
        catch(error){
            throw new Error(`Error Fetching City List: ${error}`)
        }
    }

    const {data, error, isLoading, isError} = useQuery<ICity[], Error>({
        queryKey: ["cities"],
        queryFn: fetchCity
    })

    if(isError) return <div>Error Occurred: ${error.message}</div>

    if(isLoading) return <div>Loading...</div>

    console.log("city :", data)

  return (
    <div className="mt-[30px]">
        <table className="min-w-full text-left text-sm font-light ml-6 mt-5">
        <thead className="border-b font-medium dark:border-neutral-500">
            <tr>
            <th>No.</th>
            <th>City Name</th>
            </tr>
        </thead>

        <tbody>
            {
            data?.map((city, index) => (
                <tr key={city.cityId} className="text-gray-900">
                <td>{index + 1}</td>
                <td>{city.cityName}</td>
                </tr>
            ))
            }
        </tbody>

        </table>
    </div>
  )
}

export default List

import { useQuery } from "@tanstack/react-query"
import BASE_URL from '../../constant/BASE_URL'
import axios from 'axios'

interface IDistrict {
    districtId: number,
    districtName: string
}

const List = () => {

    const fetchDistrict = async() => {
        try{
            const response = await axios.get<IDistrict[]>(`${BASE_URL}/District/GetAllDistricts`);
            return response.data;
        }
        catch(error){
            throw new Error(`Error Fetching State List: ${error}`)
        }
    }

    const {data, error, isError, isLoading} = useQuery<IDistrict[], Error>({
        queryKey: ["Districts"],
        queryFn: fetchDistrict
    })

    if(isError) return <div>Error Occurred: ${error.message}</div>

    if(isLoading) return <div>Loading....</div>

    console.log("Districts: ", data);

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
            data?.map((district, index) => (
                <tr key={district.districtId} className="text-gray-900">
                <td>{index + 1}</td>
                <td>{district.districtName}</td>
                </tr>
            ))
            }
        </tbody>

        </table>
   </div>
  )
}

export default List

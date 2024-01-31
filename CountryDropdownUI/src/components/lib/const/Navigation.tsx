import { HiOutlineViewGrid } from "react-icons/hi"
import { FaBuilding } from "react-icons/fa";
import { TbBuildingFactory2 } from "react-icons/tb";
import { TbBuildingPavilion } from "react-icons/tb";
import { HiBuildingLibrary } from "react-icons/hi2";
import { FaPerson } from "react-icons/fa6";

export const Dashboard_Sidebar_Link =[
    {
        key: "dashboard",
        label: "Dashboard",
        path: "/",
        icon:<HiOutlineViewGrid />
    },
    {
        key: "country",
        label: "Country",
        path: "/country/list",
        icon:<FaBuilding />
    },
    {
        key: "state",
        label: "State",
        path: "/state/list",
        icon:<TbBuildingFactory2 />
    },
    {
        key: "district",
        label: "District",
        path: "/district/list",
        icon:<TbBuildingPavilion />
    },
    {
        key: "city",
        label: "City",
        path: "/city/list",
        icon:<HiBuildingLibrary />
    },
    {
        key: "person",
        label: "Person",
        path: "/person/list",
        icon:<FaPerson />
    }
]

